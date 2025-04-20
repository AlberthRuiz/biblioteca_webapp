using AutoMapper;
using biblioteca_webapp.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace biblioteca_webapp.Controllers {
    public class LibroController : Controller {

        private readonly HttpClient _httpClient;
        private readonly string url_base = "http://localhost:5173/api/libros";
        private readonly IMapper mapper;

        public LibroController(IMapper mapper) {
            this.mapper = mapper;
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index() {
            var result = await _httpClient.GetAsync(url_base);
            if (!result.IsSuccessStatusCode)
                return NotFound();
            var content = await result.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<IEnumerable<LibroDTO>>(content);
            return View(lst);
        }


        public async Task<IActionResult> Create() {
            var autores = await obtenerAutores();
            ViewBag.autores = autores;
            return View();
        }
        
        private async Task<IEnumerable<AutorDTO>> obtenerAutores() {
            List<AutorDTO> lst = new List<AutorDTO>();
            var result = await _httpClient.GetAsync($"http://localhost:5173/api/autores");
            var content = await result.Content.ReadAsStringAsync();
            lst = JsonConvert.DeserializeObject<List<AutorDTO>>(content)!;
            return lst;
        }


    }
}
