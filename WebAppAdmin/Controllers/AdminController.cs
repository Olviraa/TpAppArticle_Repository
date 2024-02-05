using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelsCommun;
using WebAppAdmin.Repository;
using WebAppAdmin.Service;
using WebAppAdmin.Views.Admin;

namespace WebAppAdmin.Controllers
{
    [Route("/")]
    public class AdminController : Controller
    {
        private readonly AdminService _adminService;
        //private readonly APIRepo _apiRepo;
        public AdminController(AdminService adminService)
        { 
            _adminService = adminService;
            //_adminService = new AdminService();
            //_apiRepo = new APIRepo();
        }
        // GET: AdminController
        [Route("")]
        public ActionResult AdminHome()
        {
            return View();
        }
             
        [HttpGet]
        [Route("Articles")]
        public ActionResult ListeArticles()
        {
            //AdminService adminService = new AdminService();
            List<Produit> produits = new List<Produit>();
            produits = _adminService.GetListeProduitService();
            
            return View(produits);
        }

        [HttpGet]
        [Route("Historique")]
        public ActionResult Historique()
        {
            //AdminService adminService = new AdminService();
            List<Vente> ventes = new List<Vente>();
            ventes = _adminService.GetHistoriqueService();

            return View(ventes);
        }

        [HttpGet] //post,?
        [Route("Articles/{id}")]
        public ActionResult ArticleEdit(int id)
        {
            //AdminService adminService = new AdminService();
            List<Produit> produits = new List<Produit>();
            produits = _adminService.GetListeProduitService();
           
            return View(produits);
        }

        [HttpPost]
        [Route("Articles/{id}")]
        public ActionResult ArticleEditSend(int id)
        {
            int IdUpdated = id;
            string NomUpdated = Request.Form["produitNom"];
            int PrixUpdated = int.Parse(Request.Form["produitPrix"]);
            int QuantiteDisponibleUpdated = int.Parse(Request.Form["produitQuantiteDisponible"]);

            Produit produitUpdated = new Produit();
            produitUpdated.ID = IdUpdated;
            produitUpdated.Nom = NomUpdated;
            produitUpdated.Prix = PrixUpdated;
            produitUpdated.QuantiteDisponible = QuantiteDisponibleUpdated;


            //AdminService adminService = new AdminService();
            
            _adminService.UpdateProduitService(produitUpdated);

            return RedirectToAction("ListeArticles");
        }

        [HttpGet]
        [Route("Article/{id}")]
        public ActionResult ArticleSuppression(int id)
        {
            int IdDeleted = id;             
            
            //AdminService adminService = new AdminService();

            _adminService.DeleteProduitService(IdDeleted);

            return RedirectToAction("ListeArticles");
        }
        
        [HttpGet]
        [Route("Vente/{id}")]
        public ActionResult VenteSuppression(int id)
        {
            int IdDeleted = id;             

            //AdminService adminService = new AdminService();

            _adminService.DeleteVenteService(IdDeleted);

            return RedirectToAction("Historique");
        }

        [HttpGet]
        [Route("Articles/Nouveau")]
        public ActionResult ArticleNouveau()
        {
            //AdminService adminService = new AdminService();
            List<Produit> produits = new List<Produit>();
            produits = _adminService.GetListeProduitService();

            return View(produits);
        }
        [HttpPost]
        [Route("Articles/Nouveau")]
        public ActionResult ArticleNouveauSend()
        {
            //int IdUpdated = int.Parse(Request.Form["produitID"]);
            string NomUpdated = Request.Form["produitNom"];
            int PrixUpdated = int.Parse(Request.Form["produitPrix"]);
            int QuantiteDisponibleUpdated = int.Parse(Request.Form["produitQuantiteDisponible"]);

            Produit produitUpdated = new Produit();
            //produitUpdated.ID = IdUpdated;
            produitUpdated.Nom = NomUpdated;
            produitUpdated.Prix = PrixUpdated;
            produitUpdated.QuantiteDisponible = QuantiteDisponibleUpdated;


            //AdminService adminService = new AdminService();

            _adminService.CreateProduitService(produitUpdated);

            return RedirectToAction("ListeArticles");
        }


    }
}
