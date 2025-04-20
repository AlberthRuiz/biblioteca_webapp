using AutoMapper;
using biblioteca_webapp.DTO;
using biblioteca_webapp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using System.Text;


namespace biblioteca_webapp.Controllers {
    public class AutorController : Controller {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        private readonly string url_base = "http://localhost:5173";
        private readonly string api_base = "/api/autores";

        public AutorController(IMapper mapper) {
            _httpClient = new HttpClient();
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            // Inicializa la lista de autores
            List<AutorDTO> lst = new List<AutorDTO>();
            // Conectar el From (Controller) - API [ApiBibliotec]
            // Ejecuta un Get y guarda los resultados en la varianle result
            var result = await _httpClient.GetAsync($"{url_base}{api_base}");
            // Valida que status code se OK (200)
            if (!result.IsSuccessStatusCode)
                // Caso no sea OK envia un BadRequest como respuesta a la vista
                return BadRequest();
            // Si la validacion fue exitosa 
            // Se obtiene el contenido del resultado / JSON String 
            var content = await result.Content.ReadAsStringAsync();
            // Deserializar el contenido (formato JSON) a formato Lista Autores
            // Una vez deserializado se alamecena en la variable lst
            lst = JsonConvert.DeserializeObject<List<AutorDTO>>(content)!;
            // Retorna la lista a la vista          

            return View(lst);
        }

        public async Task<IActionResult> Edit(int id) {
            // Conectar el From (Controller) - API [ApiBibliotec]
            // Ejecuta un Get y guarda los resultados en la varianle result
            var result = await _httpClient.GetAsync( $"{url_base}{api_base}/detalle/{id}");
            // Valida que status code se OK (200)
            if (!result.IsSuccessStatusCode)
                // Caso no sea OK envia un BadRequest como respuesta a la vista
                return BadRequest();
            // Si la validacion fue exitosa 
            // Se obtiene el contenido del resultado / JSON String 
            var content = await result.Content.ReadAsStringAsync();
            // Deserializar el contenido (formato JSON) a formato Lista Autores
            // Una vez deserializado se alamecena en la variable lst
            var autorDTO = JsonConvert.DeserializeObject<AutorCreacionDTO>(content)!;            
            return View(autorDTO);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AutorCreacionDTO autorCreacionDTO) {
            if (ModelState.IsValid) {
                var json = JsonConvert.SerializeObject(autorCreacionDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{url_base}{api_base}", content);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", "Error al actualizar el autor");
            }
            return View(autorCreacionDTO);
        }

        [HttpPost]        
        public async Task<IActionResult> Edit(int id, AutorCreacionDTO autorDTO) {
            if (ModelState.IsValid) {
                var json = JsonConvert.SerializeObject(autorDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(  $"{url_base}{api_base}/{id}", content);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError("", "Error al actualizar el autor");
            }
            return View(autorDTO);
        }

    }
}
