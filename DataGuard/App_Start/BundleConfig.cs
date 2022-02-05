using System.Web.Optimization;

namespace DataGuard
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //調試環境下的
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //【bootstrap 4.1】
            bundles.Add(new StyleBundle("~/AdminLTE3/plugins/CSS/bootstrap4.1").Include(
                      "~/AdminLTE3/plugins/bootstrap/css/bootstrap.css"));
            bundles.Add(new ScriptBundle("~/bootstrap4.1/popper.js").Include(
                     "~/AdminLTE3/plugins/popper/umd/popper.js"));
            bundles.Add(new ScriptBundle("~/AdminLTE3/js/plugins/bootstrap4.1").Include(
                    "~/AdminLTE3/plugins/bootstrap/js/bootstrap.min.js"));


            //--------------------------------------------------------------------------
            //<!--Bootstrap4.4.1-->
            bundles.Add(new ScriptBundle("~/Bootstrap4.4.1/bootstrap.min.js").Include(
                      "~/AdminLTE3/plugins/bootstrap-4.4.1-dist/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Bootstrap4.4.1/bootstrap.css").Include(
                      "~/AdminLTE3/plugins/bootstrap-4.4.1-dist/css/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/Bootstrap4.4.1/popper.js").Include(
                      "~/AdminLTE3/plugins/popper.js-master/dist/popper.min.js"));

            //--------------------------------------------------------------------------

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/AdminLTE3/jQueryUI").Include(
                        "~/AdminLTE3/plugins/jQueryUI/jquery-ui.min.js"));

            // plugins | jquery.unobtrusive-ajax 
            bundles.Add(new ScriptBundle("~/Scripts/jquery.unobtrusive-ajax").Include(
                                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            //moment.js
            bundles.Add(new ScriptBundle("~/Scripts/moment").Include("~/Scripts/moment.js"));

            //AdminLTE3 JS
            bundles.Add(new ScriptBundle("~/AdminLTE3/adminlte").Include(
                     "~/AdminLTE3/dist/js/adminlte.js"));
            // angularJS 
            bundles.Add(new ScriptBundle("~/Scripts/angular").Include(
                                         "~/Scripts/angular.js"));

            // Slim Scroll
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/slimscroll").Include(
                                         "~/AdminLTE3/plugins/slimscroll/jquery.slimscroll.js"));

            //  FastClick 
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/fastclick").Include(
                                       "~/AdminLTE3/plugins/fastclick/fastclick.js"));

            // bootstrap  datepicker 
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/bootstrap-datepicker").Include(
                                        "~/AdminLTE3/plugins/datepicker/bootstrap-datepicker.js"));
            //daterangepicker
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/daterangepicker/daterangepicker").Include(
                                        "~/AdminLTE3/plugins/daterangepicker/daterangepicker.js"));
            //<!-- Daterange picker -->
            bundles.Add(new StyleBundle("~/AdminLTE3/daterangepicker").Include(
                      "~/AdminLTE3/plugins/daterangepicker/daterangepicker.css"));


            //--jQuery Knob Chart --> 
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/knob").Include(
                                        "~/AdminLTE3/plugins/knob/jquery.knob.js"));

            //jvectormap  
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/jvectormap").Include(
                                         "~/AdminLTE3/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                                         "~/AdminLTE3/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"));

            // bootstrap3-wysihtml5
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/bootstrap3-wysihtml5").Include(
                                         "~/AdminLTE3/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"));

            //<!-- Morris chart -->
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/morris").Include(
                     "~/AdminLTE3/plugins/morris/morris.min.js"));

            //<!-- icheck --> 
            // iCheck 
            bundles.Add(new StyleBundle("~/AdminLTE3/plugins/iCheck").Include(
                     "~/AdminLTE3/plugins/iCheck/flat/blue.css"));
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/icheck").Include(
                     "~/AdminLTE3/plugins/iCheck/icheck.min.js"));

            //<!-- chart.js --> 
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/chart.js").Include(
                     "~/AdminLTE3/plugins/chart.js/Chart.min.js"));

            //=Style================================================================================================================

            // bootstrap3.7
            bundles.Add(new StyleBundle("~/Content/bootstrap3.7").Include(
                      "~/Content/bootstrap.css"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap3.7").Include(
                      "~/Scripts/bootstrap.js"));

            //<!--mainStyle.css-->
            bundles.Add(new StyleBundle("~/Content/mainStyle").Include(
                      "~/Content/mainStyle.css"));

            //<!--Site.css-->
            bundles.Add(new StyleBundle("~/Content/css/site").Include(
                      "~/Content/Site.css"));

            //<!--AdminLTE3/dist/css-->
            bundles.Add(new StyleBundle("~/AdminLTE3/dist/css").Include(
                      "~/AdminLTE3/dist/css/adminlte.css"));

            //<!--font-awesome-->
            bundles.Add(new StyleBundle("~/AdminLTE3/font-awesome").Include(
                      "~/AdminLTE3/plugins/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/AdminLTE3/font-awesomeV502").Include(
                      "~/AdminLTE3/plugins/fontawesome-free-5.0.2/web-fonts-with-css/css/fontawesome-all.css"));

            // <!--datepicker3-->
            bundles.Add(new StyleBundle("~/AdminLTE3/datepicker3").Include(
                      "~/AdminLTE3/plugins/datepicker/datepicker3.css"));


            //bootstrap3-wysihtml5
            bundles.Add(new StyleBundle("~/AdminLTE3/plugins/bootstrap3-wysihtml5").Include(
                      "~/AdminLTE3/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"));

            //jvectormap  
            bundles.Add(new StyleBundle("~/AdminLTE3/plugins/jvectormap").Include(
                     "~/AdminLTE3/plugins/jvectormap/jquery-jvectormap-1.2.2.css"));

            //<!-- Morris chart -->
            bundles.Add(new StyleBundle("~/AdminLTE3/plugins//morris").Include(
                     "~/AdminLTE3/plugins/morris/morris.css"));

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //plugins | bootstrap-dialog
            bundles.Add(new StyleBundle("~/AdminLTE3/plugins/bootstrap-dialog/css").Include("~/AdminLTE3/plugins/bootstrap-dialog/css/bootstrap-dialog.css"));
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/bootstrap-dialog/js").Include("~/AdminLTE3/plugins/bootstrap-dialog/js/bootstrap-dialog.js"));
            // bootstrap4-dialogs 
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/bootstrap4-dialogs").Include("~/AdminLTE3/plugins/bootstrap4-dialogs/dist/bootstrap4-dialogs.min.js"));

            // Layer UI >Layer v3.1
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/layer-v3.1.1/layer").Include("~/AdminLTE3/plugins/layer-v3.1.1/layer/layer.js"));

            // AdminLTE3/plugins/datetimepicker
            bundles.Add(new StyleBundle("~/AdminLTE3/plugins/datetimepicker/css").Include("~/AdminLTE3/plugins/datetimepicker/css/bootstrap-datetimepicker.css"));
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/datetimepicker").Include("~/AdminLTE3/plugins/datetimepicker/js/bootstrap-datetimepicker.js"));

            // AdminLTE3/plugins/clipboard
            bundles.Add(new ScriptBundle("~/AdminLTE3/plugins/clipboard").Include("~/AdminLTE3/plugins/clipboard/dist/clipboard.min.js"));
            // /JS/Main.js
            bundles.Add(new ScriptBundle("~/JS").Include(
                        "~/JS/Main.js"));
        }
    }
}
