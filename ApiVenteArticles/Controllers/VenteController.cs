using ApiVenteArticles.Interface;
using ApiVenteArticles.Repositories;
using ApiVenteArticles.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsCommun;

namespace ApiVenteArticles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenteController : ControllerBase
    {

        IVenteService _venteService;
        

        public VenteController(IVenteService venteService)
        {
            _venteService = venteService;
        }

        [HttpGet]
        [Route("")]
        public List<Vente> GetVentes()
        {
            var ventes = _venteService.GetVentes();
            return ventes;
        }

        [HttpGet]
        [Route("{id}")]
        public Vente GetVente(int id)
        {
            var vente = _venteService.GetVente(id);
            return vente;
        }


        [HttpPost]
        [Route("add")]
        public Vente AddVente(Vente vente)
        {
            var addedVente = _venteService.AddVente(vente);
            return addedVente;
        }

        [HttpPost]
        [Route("update")]
        public Vente UpdateVente(Vente venteToUpdate)
        {
            var updatedVente = _venteService.UpdateVente(venteToUpdate.ID, venteToUpdate.Date, venteToUpdate.Total);
            return updatedVente;

        }

        [HttpPost]
        [Route("delete/{id}")]
        public void DeleteVente(int id)
        {


            _venteService.DeleteVente(id);

        }


    }
}
