using System.Web;
using System.Web.Optimization;

namespace BEEKP
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BundleTable.EnableOptimizations = true;

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));






            //bundles.Add(new StyleBundle("~/css").Include(
            //         "~/css/bootstrap.min.css",
            //         "~/css/jquery-ui.min.css",
            //         "~/css/animate.css",
            //         "~/css/css-plugin-collections.css",
            //         "~/css/menuzord-skins/menuzord-rounded-boxed.css",
            //         "~/css/style-main.css",
            //         "~/css/custom-bootstrap-margin-padding.css",
            //         "~/css/responsive.css",
            //         "~/js/revolution-slider/css/settings.css",
            //         "~/js/revolution-slider/css/layers.css",
            //         "~/js/revolution-slider/css/navigation.css",
            //         "~/css/colors/theme-skin-color-set-1.css"));

            //bundles.Add(new ScriptBundle("~/bundles/js").Include(
            //         "~/js/jquery-2.2.4.min.js",
            //         "~/js/jquery-ui.min.js",
            //         "~/js/bootstrap.min.js",
            //         "~/js/custom.js"));

            //==================Website=============================
               bundles.Add(new StyleBundle("~/bundles/css").Include(
                       "~/css/bootstrap.css",
                       "~/css/jquery-ui.css",
                       "~/css/animate.css",
                       "~/css/css-plugin-collections.css",
                       "~/css/menuzord-skins/menuzord-rounded-boxed.css",
                       "~/css/style-main.css",
                       "~/css/preloader.css",
                       "~/css/custom-bootstrap-margin-padding.css",
                       "~/css/responsive.css",                       
                       "~/js/revolution-slider/css/settings.css",
                       "~/js/revolution-slider/css/layers.css",
                       "~/js/revolution-slider/css/navigation.css",
                       "~/css/colors/theme-skin-color-set-1.css",
                       "~/css/style-custom.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                         "~/js/jquery-2.2.4.js",
                         "~/js/jquery-ui.js",
                         "~/js/bootstrap.js",
                         "~/js/jquery-plugin-collection.js",
                         "~/js/revolution-slider/js/jquery.themepunch.tools.js",
                         "~/js/revolution-slider/js/jquery.themepunch.revolution.js",
                         "~/js/custom.js",
                         "~/js/revolution-slider/js/extensions/revolution.extension.layeranimation.js",
                         "~/js/revolution-slider/js/extensions/revolution.extension.navigation.js",
                         "~/js/revolution-slider/js/extensions/revolution.extension.parallax.js",
                         "~/js/revolution-slider/js/extensions/revolution.extension.slideanims.js",
                         "~/js/revolution-slider/js/extensions/revolution.extension.video.min.js"));

            //==================Website=============================

            //==================Admin=============================
            #region globalcss
            bundles.Add(new StyleBundle("~/bundles/area/css").Include(
                      "~/assets/global/plugins/bootstrap/css/bootstrap.css",
                      //"~/assets/global/plugins/font-awesome/css/font-awesome.css",
                      "~/assets/global/plugins/simple-line-icons/simple-line-icons.css",
                      "~/assets/global/plugins/uniform/css/uniform.default.css",
                      "~/assets/global/plugins/select2/select2.css",
                      "~/assets/global/plugins/datatables/extensions/Scroller/css/dataTables.scroller.css",
                      "~/assets/global/plugins/datatables/extensions/ColReorder/css/dataTables.colReorder.css",
                      "~/assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css",
                      "~/assets/global/plugins/bootstrap-toastr/toastr.css",
                      "~/assets/global/css/components-rounded.css",
                      "~/assets/global/css/plugins.css",
                      "~/assets/admin/layout3/css/layout.css",
                      "~/assets/admin/layout3/css/themes/default.css",
                      "~/assets/admin/layout3/css/custom.css",
                      "~/assets/admin/layout3/css/style-bootstrap-file.css",
                      "~/css/bootstrap-datetimepicker.css",
                      "~/assets/admin/layout3/css/style-admin.css"));
            #endregion

            #region globaljs
            bundles.Add(new ScriptBundle("~/bundles/area/js/global").Include(
                    "~/assets/global/plugins/bootstrap/js/bootstrap.js",
                    "~/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.js",
                    "~/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.js",
                    "~/assets/global/plugins/jquery.blockui.js",
                    "~/assets/global/plugins/jquery.cokie.js",
                    "~/assets/global/plugins/uniform/jquery.uniform.js",
                    "~/assets/global/plugins/bootstrap-confirmation/bootstrap-confirmation.js",
                    "~/assets/global/scripts/metronic.js"));

            #endregion

            #region datatablesjs
            bundles.Add(new ScriptBundle("~/bundles/area/js/datatables").Include(
                    "~/assets/global/plugins/select2/select2.js",
                    "~/assets/global/plugins/datatables/media/js/jquery.dataTables.js",
                    "~/assets/global/plugins/datatables/extensions/TableTools/js/dataTables.tableTools.js",
                    "~/assets/global/plugins/datatables/extensions/ColReorder/js/dataTables.colReorder.js",
                    "~/assets/global/plugins/datatables/extensions/Scroller/js/dataTables.scroller.js",
                    "~/assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js"));

            #endregion

            #region validate
            bundles.Add(new ScriptBundle("~/bundles/area/js/validate").Include(
                   "~/assets/global/plugins/jquery-validation/js/jquery.validate.js",
                   "~/assets/global/plugins/jquery-validation/js/additional-methods.js"));
            #endregion
            #region datetimepicker
            bundles.Add(new ScriptBundle("~/bundles/area/js/datetimepicker").Include(
                   "~/js/bootstrap-datetimepicker.js"));
            #endregion


            #region filejs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/file_index").Include(
                    "~/AppJS/File/File_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/file_manage").Include(
                   "~/AppJS/File/File_Manage.js"));
            #endregion

            #region msmejs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/msme_index").Include(
                   "~/AppJS/MSME/MSME_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/msme_manage").Include(
                    "~/AppJS/MSME/MSME_Manage.js"));
            #endregion

            #region bankfinancialjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/bankfinancial_index").Include(
                   "~/AppJS/BankFinancial/BankFinancial_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/bankfinancial_manage").Include(
                    "~/AppJS/BankFinancial/BankFinancial_Manage.js"));
            #endregion


            #region manufacturersjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/manufacturers_index").Include(
                   "~/AppJS/Manufacturers/Manufacturers_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/manufacturers_manage").Include(
                    "~/AppJS/Manufacturers/Manufacturers_Manage.js"));
            #endregion

            #region faqcategoryjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/faqcategory_index").Include(
                   "~/AppJS/FAQCategory/FAQCategory_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/faqcategory_manage").Include(
                    "~/AppJS/FAQCategory/FAQCategory_Manage.js"));
            #endregion

            #region faqjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/faq_index").Include(
                   "~/AppJS/FAQ/FAQ_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/faq_manage").Include(
                    "~/AppJS/FAQ/FAQ_Manage.js"));
            #endregion

            #region energyprofessionalsjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/energyprofessionals_index").Include(
                   "~/AppJS/EnergyProfessionals/EnergyProfessionals_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/energyprofessionals_manage").Include(
                    "~/AppJS/EnergyProfessionals/EnergyProfessionals_Manage.js"));
            #endregion

            #region eventjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/event_index").Include(
                   "~/AppJS/Event/Event_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/event_addedit").Include(
                    "~/AppJS/Event/Event_AddEdit.js"));
            #endregion

            #region discussionforumjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/discussionforum_index").Include(
                   "~/AppJS/DiscussionForum/DiscussionForum_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/discussionforum_manage").Include(
                    "~/AppJS/DiscussionForum/DiscussionForum_Manage.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/discussionforumapprove").Include(
                    "~/AppJS/DiscussionForum/DiscussionForumApprove.js"));
            #endregion

            #region ClusterDetailsjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/clusterdetails_index").Include(
                    "~/AppJS/ClusterDetails/ClusterDetails_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/clusterdetails_manage").Include(
                   "~/AppJS/ClusterDetails/ClusterDetails_Manage.js"));
            #endregion

            #region Cityjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/city_index").Include(
                    "~/AppJS/City/City_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/city_manage").Include(
                   "~/AppJS/City/City_Manage.js"));
            #endregion

            #region rolejs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/role_index").Include(
                    "~/AppJS/Role/Role_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/role_manage").Include(
                   "~/AppJS/Role/Role_Manage.js"));
            #endregion

            #region photojs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/photo_index").Include(
                   "~/AppJS/Gallery/PhotoGallery_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/photo_manage").Include(
                    "~/AppJS/Gallery/PhotoGallery_Manage.js"));
            #endregion

            #region videojs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/video_index").Include(
                   "~/AppJS/Gallery/VideoGallery_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/video_manage").Include(
                    "~/AppJS/Gallery/VideoGallery_Manage.js"));
            #endregion

            #region Sectorjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/sector_index").Include(
                    "~/AppJS/Sector/Sector_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/sector_manage").Include(
                   "~/AppJS/Sector/Sector_Manage.js"));
            #endregion

            #region projectcomponentjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/projectcomponent_index").Include(
                   "~/AppJS/ProjectComponent/ProjectComponent_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/projectcomponent_manage").Include(
                    "~/AppJS/ProjectComponent/ProjectComponent_Manage.js"));
            #endregion
            
            #region knowledgebankjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/knowledgebank_index").Include(
                   "~/AppJS/KnowledgeBank/KnowledgeBank_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/knowledgebank_manage").Include(
                    "~/AppJS/KnowledgeBank/KnowledgeBank_Manage.js"));
            #endregion
            
            #region financingschemejs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/financingscheme_index").Include(
                   "~/AppJS/FinancingScheme/FinancingScheme_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/financingscheme_manage").Include(
                    "~/AppJS/FinancingScheme/FinancingScheme_Manage.js"));
            #endregion

            #region energytechnologiesjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/energytechnologies_index").Include(
                   "~/AppJS/EnergyTechnologies/EnergyTechnologies_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/energytechnologies_manage").Include(
                    "~/AppJS/EnergyTechnologies/EnergyTechnologies_Manage.js"));
            #endregion
            
            #region casestudyjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/casestudy_index").Include(
                   "~/AppJS/CaseStudy/CaseStudy_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/casestudy_manage").Include(
                    "~/AppJS/CaseStudy/CaseStudy_Manage.js"));
            #endregion

            #region newsletterjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/newsletter_index").Include(
                   "~/AppJS/NewsLetter/NewsLetter_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/casestudy_manage").Include(
                    "~/AppJS/CaseStudy/CaseStudy_Manage.js"));
            #endregion

            #region announcementsjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/announcements_index").Include(
                   "~/AppJS/Announcements/Announcements_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/announcements_addedit").Include(
                    "~/AppJS/Announcements/Announcements_AddEdit.js"));
            #endregion

            #region newsjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/news_index").Include(
                   "~/AppJS/News/News_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/news_addedit").Include(
                    "~/AppJS/News/News_AddEdit.js"));
            #endregion

            #region phasesjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/phases_index").Include(
                   "~/AppJS/Phases/Phases_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/Phases_addedit").Include(
                    "~/AppJS/Phases/Phases_AddEdit.js"));
            #endregion

            #region loanjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/loan_index").Include(
                   "~/AppJS/Loan/Loan_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/loan_manage").Include(
                    "~/AppJS/Loan/Loan_Manage.js"));
            #endregion

            #region subsidyjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/subsidy_index").Include(
                   "~/AppJS/Subsidy/Subsidy_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/subsidy_manage").Include(
                    "~/AppJS/Subsidy/Subsidy_Manage.js"));
            #endregion

            #region sectorsjs
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/sectors_index").Include(
                   "~/AppJS/Sectors/Sectors_Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/area/appjs/sectors_addedit").Include(
                    "~/AppJS/Sectors/Sectors_AddEdit.js"));
            #endregion
            //==================Admin=============================


        }
    }
}
