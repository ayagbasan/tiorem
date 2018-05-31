<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="tiorem.editor.Error" %>


<!DOCTYPE html>
<!--
This is a starter template page. Use this page to start your new project from
scratch. This page gets rid of all links and provides the needed markup only.
-->
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>TİOREM | EDITOR</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">

    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="/assets/css/AdminLTE.css" rel="stylesheet" />
    <link href="/assets/css/_all-skins.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">

    <script type="text/javascript">
        //function showSuccessAlert(title,content) {  

        //    $("#msgTitleSuccess").html(title);
        //    $("#msgContentSuccess").html(content);

        //    $("#modal-success").modal({ backdrop: true });

        //}

        //function showErrorAlert(title,content) {  
        //    $("#msgTitleError").html(title);
        //    $("#msgContentError").html(content);

        //    $("#modal-danger").modal({ backdrop: true });
        //}

        function showAlert(type, title, content) {

            alert(content);
        }


        function refreshGrid() {

            gridCagriBilgileri.Refresh();
        }


    </script>
</head>
<!--
BODY TAG OPTIONS:
=================
Apply one or more of the following classes to get the
desired effect
|---------------------------------------------------------|
| SKINS         | skin-blue                               |
|               | skin-black                              |
|               | skin-purple                             |
|               | skin-yellow                             |
|               | skin-red                                |
|               | skin-green                              |
|---------------------------------------------------------|
|LAYOUT OPTIONS | fixed                                   |
|               | layout-boxed                            |
|               | layout-top-nav                          |
|               | sidebar-collapse                        |
|               | sidebar-mini                            |
|---------------------------------------------------------|
-->
<body class="hold-transition skin-blue sidebar-mini">
    <form runat="server" id="mainForm">


        <div class="wrapper">

            <!-- Main Header -->
            <header class="main-header">

                <!-- Logo -->

                <!-- Header Navbar -->
                <nav class="navbar navbar-static-top" role="navigation">
                    <!-- Sidebar toggle button-->
                    <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
                        <span class="sr-only">Toggle navigation</span>
                    </a>

                    <!-- Navbar Right Menu -->
                    <div class="navbar-custom-menu">
                        <ul class="nav navbar-nav">





                            <!-- User Account Menu -->
                            <li class="dropdown user user-menu">
                                <!-- Menu Toggle Button -->
                                <%--  <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                  
                                    <img id="img1" runat="server" width="24" class="img-circle">
                                    <span class="hidden-xs text-right">
                                        <asp:Literal ID="litUserAdiSoyadi1" runat="server"></asp:Literal>
                                    </span>
                                   
                              
                                </a>--%>
 
                            </li>
                            <!-- Control Sidebar Toggle Button -->
                            <%-- <li>
                                <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
                            </li>--%>
                        </ul>
                    </div>
                </nav>
            </header>
            <!-- Left side column. contains the logo and sidebar -->
            <aside class="main-sidebar" style="padding-top: 10px">

                <!-- sidebar: style can be found in sidebar.less -->
                <section class="sidebar">

                 
                    <div class="user-panel text-center">
                        <a href="/default.aspx" class="logo">
                            <img src="/assets/img/logo.png" height="50" />
                        </a>
                        <a href="/default.aspx" class="logo">
                            <!-- mini logo for sidebar mini 50x50 pixels -->
                            <div class="logo-mini"><b>TİOREM</b></div>
                            <!-- logo for regular state and mobile devices -->
                            <div class="logo-lg">
                                <b>EDITOR</b>
                            </div>
                        </a>
                    </div>
                    <!-- Sidebar user panel (optional) -->
                    <hr class="bg-gray" />
                    <div class="user-panel">
                        <div class="pull-left image">
                            <img id="img3" runat="server" width="24" class="img-circle">
                        </div>
                        <div class="pull-left info">
                            <p>
                                <asp:Literal ID="litUserAdiSoyadi2" runat="server"></asp:Literal>
                            </p>
                            <!-- Status -->
                            <a href="#" style="white-space: normal">
                                <asp:Literal ID="litBirim1" runat="server"></asp:Literal></a>
                        </div>
                    </div>

                    <!-- search form (Optional) -->
                    <%--  <form action="#" method="get" class="sidebar-form">
                        <div class="input-group">
                            <input type="text" name="q" class="form-control" placeholder="Search...">
                            <span class="input-group-btn">
                                <button type="submit" name="search" id="search-btn" class="btn btn-flat">
                                    <i class="fa fa-search"></i>
                                </button>
                            </span>
                        </div>
                    </form>--%>
                    <!-- /.search form -->

                    <!-- Sidebar Menu -->
                    <ul class="sidebar-menu" data-widget="tree">
                        <li class="header">Menü</li>
                        <li id="menu1"><a href="/Default.aspx"><i class="fa fa-edit"></i><span>Ana Sayfa</span></a></li>


                    </ul>
                    <!-- /.sidebar-menu -->
                </section>
                <!-- /.sidebar -->
            </aside>

            <!-- Content Wrapper. Contains page content -->
            <div class="content-wrapper">
                <section class="content container-fluid">

                    <div class="login-box" style="width: 700px">

                        <div class="box box-primary" style="min-height: 250px;">
                            <div class="box-header with-border">
                                <h3 class="box-title">HATA</h3>


                            </div>

                            <div class="box-body pad">




                                <p class="card-text">

                                    <blockquote>
                                        <p>
                                            <asp:Literal ID="mesaj1" runat="server"></asp:Literal>
                                        </p>
                                        <small><cite>
                                            <asp:Literal ID="mesaj2" runat="server"></asp:Literal>


                                        </cite></small>
                                    </blockquote>


                                    <br />


                                </p>
                                <p class="card-text">
                                    <small class="text-muted">


                                        <asp:HyperLink ID="HyperLink1" runat="server">Hata Mesajını Bildir</asp:HyperLink>
                                        | <a href="pages/default.aspx">Ana Sayfa</a>

                                        |
                                        <asp:HyperLink ID="HyperLink2" runat="server">Yeniden Dene</asp:HyperLink>
                                    </small>
                                </p>
                            </div>

                        </div>
                    </div>

                </section>



            </div>
            <!-- /.content-wrapper -->

            <!-- Main Footer -->
            <footer class="main-footer">
                <!-- To the right -->
                <div class="pull-right hidden-xs">
                    AYMK

   
                </div>
                <!-- Default to the left -->
                <strong>Copyright &copy; 2018 <a href="#" class="text-maroon">AYMK</a></strong>

            </footer>

            <!-- Control Sidebar -->
            <aside class="control-sidebar control-sidebar-dark">
                <!-- Create the tabs -->
                <ul class="nav nav-tabs nav-justified control-sidebar-tabs">
                    <li class="active"><a href="#control-sidebar-home-tab" data-toggle="tab"><i class="fa fa-home"></i></a></li>
                    <li><a href="#control-sidebar-settings-tab" data-toggle="tab"><i class="fa fa-gears"></i></a></li>
                </ul>
                <!-- Tab panes -->
                <div class="tab-content">
                    <!-- Home tab content -->
                    <div class="tab-pane active" id="control-sidebar-home-tab">
                        <h3 class="control-sidebar-heading">Recent Activity</h3>
                        <ul class="control-sidebar-menu">
                            <li>
                                <a href="javascript:;">
                                    <i class="menu-icon fa fa-birthday-cake bg-red"></i>

                                    <div class="menu-info">
                                        <h4 class="control-sidebar-subheading">Langdon's Birthday</h4>

                                        <p>Will be 23 on April 24th</p>
                                    </div>
                                </a>
                            </li>
                        </ul>
                        <!-- /.control-sidebar-menu -->

                        <h3 class="control-sidebar-heading">Tasks Progress</h3>
                        <ul class="control-sidebar-menu">
                            <li>
                                <a href="javascript:;">
                                    <h4 class="control-sidebar-subheading">Custom Template Design
               
                                        <span class="pull-right-container">
                                            <span class="label label-danger pull-right">70%</span>
                                        </span>
                                    </h4>

                                    <div class="progress progress-xxs">
                                        <div class="progress-bar progress-bar-danger" style="width: 70%"></div>
                                    </div>
                                </a>
                            </li>
                        </ul>
                        <!-- /.control-sidebar-menu -->

                    </div>
                    <!-- /.tab-pane -->
                    <!-- Stats tab content -->
                    <div class="tab-pane" id="control-sidebar-stats-tab">Stats Tab Content</div>
                    <!-- /.tab-pane -->
                    <!-- Settings tab content -->
                    <div class="tab-pane" id="control-sidebar-settings-tab">
                        <form method="post">
                            <h3 class="control-sidebar-heading">General Settings</h3>

                            <div class="form-group">
                                <label class="control-sidebar-subheading">
                                    Report panel usage
             
                                    <input type="checkbox" class="pull-right" checked>
                                </label>

                                <p>
                                    Some information about this general settings option
           
                                </p>
                            </div>
                            <!-- /.form-group -->
                        </form>
                    </div>
                    <!-- /.tab-pane -->
                </div>
            </aside>
            <!-- /.control-sidebar -->
            <!-- Add the sidebar's background. This div must be placed
  immediately after the control sidebar -->
            <div class="control-sidebar-bg"></div>
        </div>




    </form>
    <script src="/assets/js/jquery.min.js"></script>
    <script src="/assets/js/bootstrap.min.js"></script>
    <script src="/assets/js/adminlte.min.js"></script>




</body>
</html>


