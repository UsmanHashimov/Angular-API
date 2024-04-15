using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TicketingSystem.Application.Abstractions.IRepositories;
using TicketingSystem.Application.Abstractions.IServices;
using TicketingSystem.Domain.Entities.DTOs;
using TicketingSystem.Domain.Entities.Exceptions;
using TicketingSystem.Domain.Entities.Models;
using TicketingSystem.Domain.Entities.ViewModels;
namespace TicketingSystem.Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Create(UserDTO userDTO)
        {
            var email = await _userRepository.GetByAny(x => x.Email == userDTO.Email);
            var username = await _userRepository.GetByAny(x => x.Username == userDTO.Username);
            if (username == null)
            {
                if (email == null)
                {
                    var user = new User()
                    {
                        Username = userDTO.Username,
                        Email = userDTO.Email,
                        Login = userDTO.Login,
                        Password = userDTO.Password,
                        role = userDTO.role,
                    };
                    var result = await _userRepository.Create(user);

                    return "You succesfully registered!";
                }
                return "This email already exists";
            }
            return "This username already exists";
        }

        public async Task<string> Delete(int id)
        {
            var result = await _userRepository.Delete(x => x.Id == id);
            if (result)
            {
                return "Deleted";
            }
            else
            {
                throw new UserNotFoundException("User not found!");
            }
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await _userRepository.GetAll();

            var result = users.Select(model => new UserViewModel
            {
                Id = model.Id,
                Username = model.Username,
                Email = model.Email,
                TicketId = model.TicketId
            });

            return result;
        }

        public async Task<UserViewModel> GetByEmail(string email)
        {
            var result = await _userRepository.GetByAny(x => x.Email == email);
            if (result != null)
            {
                var res = new UserViewModel()
                {
                    Id = result.Id,
                    Username = result.Username,
                    Email = result.Email,
                    TicketId = result.TicketId
                };
                return res;
            }
            throw new UserNotFoundException("User not found!");
        }

        public async Task<UserViewModel> GetById(int Id)
        {
            var result = await _userRepository.GetByAny(x => x.Id == Id);
            if (result != null)
            {
                var res = new UserViewModel()
                {
                    Id = result.Id,
                    Username = result.Username,
                    Email = result.Email,
                    TicketId = result.TicketId
                };
                return res;
            }
            throw new UserNotFoundException("User not found!");
        }

        public async Task<UserViewModel> GetByName(string name)
        {
            var result = await _userRepository.GetByAny(d => d.Username == name);
            if (result != null)
            {
                var res = new UserViewModel()
                {
                    Id = result.Id,
                    Username = result.Username,
                    Email = result.Email,
                    TicketId = result.TicketId
                };
                return res;
            }
            throw new UserNotFoundException("User not found!");
        }

        public async Task<string> Update(int Id, UserDTO userDTO)
        {
            var res = await _userRepository.GetAll();
            var email = res.Any(x => x.Email == userDTO.Email);
            var name = res.Any(x => x.Username == userDTO.Username);
            if (!email)
            {
                if (!name)
                {
                    var old = await _userRepository.GetByAny(x => x.Id == Id);

                    if (old == null) return "Failed";
                    old.Username = userDTO.Username;
                    old.Password = userDTO.Password;
                    old.Email = userDTO.Email;
                    old.role = userDTO.role;


                    await _userRepository.Update(old);
                    return "Updated";

                }
                return "Such login already exists";
            }
            return "Such email already exists";
        }

        public async Task<string> GetPdfPath()
        {

            var text = "";

            var getall = await _userRepository.GetAll();
            foreach (var user in getall.Where(x => x.role != "Admin"))
            {
                text = text + $"{user.Username}|{user.Email}\n";
            }

            DirectoryInfo projectDirectoryInfo =
            Directory.GetParent(Environment.CurrentDirectory).Parent.Parent;

            var file = Guid.NewGuid().ToString();

            string pdfsFolder = Directory.CreateDirectory(
                 Path.Combine(projectDirectoryInfo.FullName, "pdfs")).FullName;

            QuestPDF.Settings.License = LicenseType.Community;

            QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                      .Text("Library Users")
                      .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                      .PaddingVertical(1, Unit.Centimetre)
                      .Column(x =>
                      {
                          x.Spacing(20);

                          x.Item().Text(text);
                      });

                    page.Footer()
                      .AlignCenter()
                      .Text(x =>
                      {
                          x.Span("Page ");
                          x.CurrentPageNumber();
                      });
                });
            })
            .GeneratePdf(Path.Combine(pdfsFolder, $"{file}.pdf"));
            return Path.Combine(pdfsFolder, $"{file}.pdf");
        }
    }
}
