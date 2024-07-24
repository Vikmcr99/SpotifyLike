using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreamingApp.API.DTO;
using StreamingApp.Application.Account;
using StreamingApp.Domain.Account;
using StreamingApp.Domain.Transaction;

namespace StreamingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService service;

        public UserController(UserService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Create(CreateUserRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            Card card = new Card()
            {
                Limit = request.Card.Limit,
                Active = request.Card.Active,
                Number = request.Card.Number

            };

            var createdUser = this.service.CreateAccount(request.Name, request.PlanId, card);

            UserResponse response = toResponse(createdUser);

            return Created($"/user/{response.Id}", response);
        }

        [HttpPost("{id}/fav/{idMusic}")]
        public IActionResult FavoriteMusic(Guid id, Guid idMusic)
        {
            this.service.FavoriteMusic(id, idMusic);

            var user = this.service.GetUserById(id);

            var response = toResponse(user);

            return Ok(response);
        }

        [HttpPost("{id}/unfav/{idMusic}")]
        public IActionResult UnfavoriteMusic(Guid id, Guid idMusic)
        {
            this.service.UnfavoriteMusic(id, idMusic);

            var user = this.service.GetUserById(id);

            var response = toResponse(user);

            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            var user = this.service.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            var response = toResponse(user);

            return Ok(response);
        }

        private static UserResponse toResponse(User createdUser)
        {
            var response = new UserResponse()
            {
                Id = createdUser.Id,
                Name = createdUser.Name,
                PlanId = createdUser.Subscriptions.FirstOrDefault(x => x.Active).Plan.Id
            };

            foreach (var item in createdUser.Playlists)
            {
                var playlistResponse = new PlaylistResponse();
                playlistResponse.Id = item.Id;
                playlistResponse.Name = item.Name;

                response.Playlists.Add(playlistResponse);

                foreach (var music in item.Musics)
                {
                    playlistResponse.Musics.Add(new MusicResponse()
                    {
                        Duraction = music.Duration,
                        Name = music.Name,
                        Id = music.Id
                    });
                }
            }

            return response;

        }
    }
}
