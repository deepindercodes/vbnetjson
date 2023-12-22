<%@ Page Language="VB" AutoEventWireup="false" CodeFile="view.aspx.vb" Inherits="view" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/js/bootstrap.bundle.min.js"></script>
    <script src="/js/jquery-3.7.1.min.js"></script>

    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet" />

    <style type="text/css">
        .articleimg {
            max-width: 200px;
            margin: 15px;
            float: left;
        }

        body {
            font-family: 'Roboto', sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="row">
                <div class="col-sm-1">
                    &nbsp;
                </div>
                <div class="col-sm-10">
                    <ul class='list-group'>
                        <li class='list-group-item fs-5 p-3 bg-primary text-white'>
                            <asp:Literal ID="litarticletitle" runat="server"></asp:Literal></li>
                        <li class='list-group-item p-2'>
                            <p>
                                <asp:Panel ID="divimage" Visible="false" runat="server">
                                    <asp:Image ID="imgarticle" runat="server" CssClass="img-fluid rounded articleimg" />
                                </asp:Panel>
                                <b>Author:</b>&nbsp;<asp:Literal ID="litarticleauthor" runat="server"></asp:Literal><br />
                                <b>Date (UTC):</b>&nbsp;<asp:Literal ID="litarticlecreatedonutc" runat="server"></asp:Literal><br />
                                <br />
                                <asp:Literal ID="litarticlebody" runat="server"></asp:Literal>
                            </p>
                        </li>
                    </ul>
                </div>
                <div class="col-sm-1">
                    &nbsp;
                </div>
            </div>
        </div>
    </form>
</body>
</html>
