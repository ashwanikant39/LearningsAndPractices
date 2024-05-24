using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BEEKP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        
        {
            //String today = System.DateTime.Today.ToShortDateString();
            String sAction = "";
            if (DateTime.Today.ToShortDateString() == "9/20/2019" || DateTime.Today.ToShortDateString() == "09/21/2019" || DateTime.Today.ToShortDateString() == "9/22/2019" || DateTime.Today.ToShortDateString() == "9/23/2019")
            {
                sAction = "Inauguration";
            }
            else
            {
                sAction = "Index";
            }

            ////temporary
            //sAction = "Index";

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /***************************************************************About us route**************************************/
            routes.MapRoute(
            name: "AboutUs",
            url: "AboutProject",
            defaults: new { controller = "AboutUs", action = "AboutProject", id = UrlParameter.Optional }
             );
            routes.MapRoute(
           name: "GEF",
           url: "GEF",
           defaults: new { controller = "AboutUs", action = "GEF", id = UrlParameter.Optional }
            );
            routes.MapRoute(
           name: "Index",
           url: "Index",
           defaults: new { controller = "AboutUs", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
           name: "AboutBEE",
           url: "AboutBEE",
           defaults: new { controller = "AboutUs", action = "AboutBEE", id = UrlParameter.Optional }
            );

            routes.MapRoute(
           name: "AboutUNIDO",
           url: "AboutUNIDO",
           defaults: new { controller = "AboutUs", action = "AboutUNIDO", id = UrlParameter.Optional }
            );

           routes.MapRoute(
           name: "AboutGef",
           url: "AboutGef",
           defaults: new { controller = "AboutUs", action = "AboutGef", id = UrlParameter.Optional }
            );


            routes.MapRoute(
           name: "Activities",
           url: "Activities",
           defaults: new { controller = "AboutUs", action = "Activities", id = UrlParameter.Optional }
            );
            routes.MapRoute(
           name: "EnergyAudits",
           url: "EnergyAudits",
           defaults: new { controller = "AboutUs", action = "EnergyAudits", id = UrlParameter.Optional }
            );
            routes.MapRoute(
           name: "EMC",
           url: "EMC",
           defaults: new { controller = "AboutUs", action = "EMC", id = UrlParameter.Optional }
            );
            routes.MapRoute(
           name: "CII",
           url: "CII",
           defaults: new { controller = "AboutUs", action = "CII", id = UrlParameter.Optional }
            );
            routes.MapRoute(
          name: "TERI",
          url: "TERI",
          defaults: new { controller = "AboutUs", action = "TERI", id = UrlParameter.Optional }
           );
            routes.MapRoute(
          name: "CapacityBuilding",
          url: "CapacityBuilding",
          defaults: new { controller = "AboutUs", action = "CapacityBuilding", id = UrlParameter.Optional }
           );

            routes.MapRoute(
           name: "InHouse",
           url: "InHouse",
           defaults: new { controller = "AboutUs", action = "InHouse", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "inhouseBelgaum",
              url: "inhouseBelgaum",
              defaults: new { controller = "AboutUs", action = "inhouseBelgaum", id = UrlParameter.Optional }
               );
            routes.MapRoute(
          name: "inhouseGujarat",
          url: "inhouseGujarat",
          defaults: new { controller = "AboutUs", action = "inhouseGujarat", id = UrlParameter.Optional }
           );
            routes.MapRoute(
          name: "inhouseIndore",
          url: "inhouseIndore",
          defaults: new { controller = "AboutUs", action = "inhouseIndore", id = UrlParameter.Optional }
           );
            routes.MapRoute(
          name: "inhouseJalandhar",
          url: "inhouseJalandhar",
          defaults: new { controller = "AboutUs", action = "inhouseJalandhar", id = UrlParameter.Optional }
           );
            routes.MapRoute(
          name: "inhouseJamnagar",
          url: "inhouseJamnagar",
          defaults: new { controller = "AboutUs", action = "inhouseJamnagar", id = UrlParameter.Optional }
           );
            routes.MapRoute(
          name: "inhouseKerala",
          url: "inhouseKerala",
          defaults: new { controller = "AboutUs", action = "inhouseKerala", id = UrlParameter.Optional }
           );
            routes.MapRoute(
          name: "inhousekhurja",
          url: "inhousekhurja",
          defaults: new { controller = "AboutUs", action = "inhousekhurja", id = UrlParameter.Optional }
           );
            routes.MapRoute(
          name: "inhouseMorbi",
          url: "inhouseMorbi",
          defaults: new { controller = "AboutUs", action = "inhouseMorbi", id = UrlParameter.Optional }
           );
            routes.MapRoute(
          name: "inhouseNagaur",
          url: "inhouseNagaur",
          defaults: new { controller = "AboutUs", action = "inhouseNagaur", id = UrlParameter.Optional }
           );
            routes.MapRoute(
          name: "inhouseThangadh",
          url: "inhouseThangadh",
          defaults: new { controller = "AboutUs", action = "inhouseThangadh", id = UrlParameter.Optional }
           );










            routes.MapRoute(
           name: "InterCluster",
           url: "InterCluster",
           defaults: new { controller = "AboutUs", action = "InterCluster", id = UrlParameter.Optional }
            );
            routes.MapRoute(
           name: "PilotProject",
           url: "PilotProject",
           defaults: new { controller = "AboutUs", action = "PilotProject", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
           name: "KnowledgeMaterials",
           url: "KnowledgeMaterials",
           defaults: new { controller = "AboutUs", action = "KnowledgeMaterials", id = UrlParameter.Optional }
            );
            routes.MapRoute(
          name: "Upscaling",
          url: "Upscaling",
          defaults: new { controller = "AboutUs", action = "Upscaling", id = UrlParameter.Optional }
           );




            routes.MapRoute(
         name: "KnowledgeLibrary",
         url: "KnowledgeLibrary",
         defaults: new { controller = "AboutUs", action = "KnowledgeLibrary", id = UrlParameter.Optional }
          );
            routes.MapRoute(
         name: "Gallery",
         url: "Gallery",
         defaults: new { controller = "AboutUs", action = "Gallery", id = UrlParameter.Optional }
          );
            routes.MapRoute(
         name: "Videos",
         url: "Videos",
         defaults: new { controller = "AboutUs", action = "Videos", id = UrlParameter.Optional }
          );
            routes.MapRoute(
         name: "CaseStudies",
         url: "CaseStudies",
         defaults: new { controller = "AboutUs", action = "CaseStudies", id = UrlParameter.Optional }
          );
            routes.MapRoute(
         name: "TrainingManuals",
         url: "TrainingManuals",
         defaults: new { controller = "AboutUs", action = "TrainingManuals", id = UrlParameter.Optional }
          );







            routes.MapRoute(
           name: "Partner_Agencies",
           url: "Partner_Agencies",
           defaults: new { controller = "AboutUs", action = "Partner_Agencies", id = UrlParameter.Optional }
            );
            routes.MapRoute(
           name: "Key_People",
           url: "Key_People",
           defaults: new { controller = "AboutUs", action = "Key_People", id = UrlParameter.Optional }
            );
            routes.MapRoute(
           name: "Bee",
           url: "Bee",
           defaults: new { controller = "AboutUs", action = "Bee", id = UrlParameter.Optional }
            );
            routes.MapRoute(
         name: "WorldBank",
         url: "WorldBank",
         defaults: new { controller = "AboutUs", action = "WorldBank", id = UrlParameter.Optional }
          );
            /***************************************************************End About us route**************************************/
            routes.MapRoute(
          name: "BankLoan",
          url: "BankLoan",
          defaults: new { controller = "FinancingScheme", action = "BankLoan", id = UrlParameter.Optional }
           );
            routes.MapRoute(
          name: "GovernmentSubsidy",
          url: "GovernmentSubsidy",
          defaults: new { controller = "FinancingScheme", action = "GovernmentSubsidy", id = UrlParameter.Optional }
           );
            routes.MapRoute(
          name: "Digital",
          url: "Digital",
          defaults: new { controller = "Library", action = "Digital", id = UrlParameter.Optional }
           );
            routes.MapRoute(
        name: "ContactUs",
        url: "ContactUs",
        defaults: new { controller = "Support", action = "ContactUs", id = UrlParameter.Optional }
         );
            routes.MapRoute(
        name: "Term_Condition",
        url: "Term_Condition",
        defaults: new { controller = "UsefulLink", action = "Term_Condition", id = UrlParameter.Optional }
         );
            routes.MapRoute(
      name: "Policy",
      url: "Policy",
      defaults: new { controller = "UsefulLink", action = "Policy", id = UrlParameter.Optional }
       );
            routes.MapRoute(
     name: "TrainingManual",
     url: "TrainingManual",
     defaults: new { controller = "Library", action = "TrainingManual", id = UrlParameter.Optional }
      );
            routes.MapRoute(
    name: "Brass",
    url: "Brass",
    defaults: new { controller = "Home", action = "Brass", id = UrlParameter.Optional },
    namespaces: new[] { "BEEKP.Controllers" }
     );
            routes.MapRoute(
   name: "Ceramic",
   url: "Ceramic",
   defaults: new { controller = "Home", action = "Ceramic", id = UrlParameter.Optional },
   namespaces: new[] { "BEEKP.Controllers" }
    );
            routes.MapRoute(
 name: "Dairy",
 url: "Dairy",
 defaults: new { controller = "Home", action = "Dairy", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  );
            routes.MapRoute(
 name: "Foundry",
 url: "Foundry",
 defaults: new { controller = "Home", action = "Foundry", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  );
routes.MapRoute(
 name: "Hand_tool",
 url: "Hand_tool",
 defaults: new { controller = "Home", action = "Hand_tool", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  );

            routes.MapRoute(
             name: "Textiles",
             url: "Textiles",
             defaults: new { controller = "Home", action = "Textiles", id = UrlParameter.Optional },
             namespaces: new[] { "BEEKP.Controllers" }
              );
            routes.MapRoute(
 name: "Foods",
 url: "Foods",
 defaults: new { controller = "Home", action = "Foods", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  );
            routes.MapRoute(
 name: "SeaFood",
 url: "SeaFood",
 defaults: new { controller = "Home", action = "SeaFood", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  );
            routes.MapRoute(
 name: "Bricks",
 url: "Bricks",
 defaults: new { controller = "Home", action = "Bricks", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  );
            routes.MapRoute(
 name: "Forging",
 url: "Forging",
 defaults: new { controller = "Home", action = "Forging", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  );
            routes.MapRoute(
 name: "Chemicals",
 url: "Chemicals",
 defaults: new { controller = "Home", action = "Chemicals", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  );
 
 routes.MapRoute(
 name: "Limekilns",
 url: "Limekilns",
 defaults: new { controller = "Home", action = "Limekilns", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  );


routes.MapRoute(
    name: "Automobile",
    url: "Automobile",
    defaults: new { controller = "Home", action = "Automobile", id = UrlParameter.Optional },
    namespaces: new[] { "BEEKP.Controllers" }
    );
routes.MapRoute(
 name: "Carpet",
 url: "Carpet",
 defaults: new { controller = "Home", action = "Carpet", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
routes.MapRoute(
 name: "Coir",
 url: "Coir",
 defaults: new { controller = "Home", action = "Coir", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
            routes.MapRoute(
 name: "Engg",
 url: "Engg",
 defaults: new { controller = "Home", action = "Engg", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
            routes.MapRoute(
 name: "Footware",
 url: "Footware",
 defaults: new { controller = "Home", action = "Footware", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
            routes.MapRoute(
 name: "Glass",
 url: "Glass",
 defaults: new { controller = "Home", action = "Glass", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
            routes.MapRoute(
 name: "Leather",
 url: "Leather",
 defaults: new { controller = "Home", action = "Leather", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
            routes.MapRoute(
 name: "Oilmill",
 url: "Oilmill",
 defaults: new { controller = "Home", action = "Oilmill", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
            routes.MapRoute(
 name: "Ornaments",
 url: "Ornaments",
 defaults: new { controller = "Home", action = "Ornaments", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
            routes.MapRoute(
 name: "Paper",
 url: "Paper",
 defaults: new { controller = "Home", action = "Paper", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
            routes.MapRoute(
 name: "Pharma",
 url: "Pharma",
 defaults: new { controller = "Home", action = "Pharma", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
            routes.MapRoute(
 name: "Refractory",
 url: "Refractory",
 defaults: new { controller = "Home", action = "Refractory", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
            routes.MapRoute(
 name: "RiceMills",
 url: "RiceMills",
 defaults: new { controller = "Home", action = "RiceMills", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
            routes.MapRoute(
 name: "Rubber",
 url: "Rubber",
 defaults: new { controller = "Home", action = "Rubber", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
            routes.MapRoute(
 name: "SteelRolling",
 url: "SteelRolling",
 defaults: new { controller = "Home", action = "SteelRolling", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
            routes.MapRoute(
 name: "Tea",
 url: "Tea",
 defaults: new { controller = "Home", action = "Tea", id = UrlParameter.Optional },
 namespaces: new[] { "BEEKP.Controllers" }
  ); 
           

            routes.MapRoute(
name: "HelpDesk",
url: "HelpDesk",
defaults: new { controller = "Support", action = "HelpDesk", id = UrlParameter.Optional }
 );
            routes.MapRoute(
name: "Other",
url: "Other",
defaults: new { controller = "Library", action = "Other", id = UrlParameter.Optional }
);
     
            routes.MapRoute(
name: "NewsLetter",
url: "NewsLetter",
defaults: new { controller = "Library", action = "NewsLetter", id = UrlParameter.Optional }
);
            routes.MapRoute(
name: "Detail",
url: "Detail",
defaults: new { controller = "Event", action = "Detail", id = UrlParameter.Optional }
);
            routes.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = sAction, id = UrlParameter.Optional },
                 namespaces: new[] { "BEEKP.Controllers" }
             );
        }
    }
}
