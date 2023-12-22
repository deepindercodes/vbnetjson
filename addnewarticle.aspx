<%@ Page Language="VB" AutoEventWireup="false" CodeFile="addnewarticle.aspx.vb" Inherits="addnewarticle" %>

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
        body {
            font-family: 'Roboto', sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">

            <div class='row p-2' id="diverror" runat="server" visible="false">
                <div class='col-sm-12'>
                    <div class='alert alert-danger'>
                        <strong>
                            <asp:Label ID="lblerror" ForeColor="Red" Text="" runat="server"></asp:Label></strong>
                    </div>
                </div>
            </div>

            <div class="row">

                <div class="col-sm-4">
                    Title
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtarticletitle" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                </div>

            </div>

            <div class="row">

                <div class="col-sm-12">
                    &nbsp;
                </div>

            </div>

            <div class="row">

                <div class="col-sm-4">
                    Author
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtarticleauthor" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                </div>

            </div>

            <div class="row">

                <div class="col-sm-12">
                    &nbsp;
                </div>

            </div>

            <div class="row">

                <div class="col-sm-4">
                    Body
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtarticlebody" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="10" Width="99%" required="required"></asp:TextBox>
                </div>

            </div>

            <div class="row">

                <div class="col-sm-12">
                    &nbsp;
                </div>

            </div>

            <div class="row">

                <div class="col-sm-4">
                    Article Image
                </div>
                <div class="col-sm-8">
                    <input type="file" id="fileArticleImage" class="form-control" style="width: 99%" />
                    <img id="imagArticlePreview" src="" class="img-fluid" style="max-width: 200px; margin-top: 5px" />
                    <asp:HiddenField ID="hdnarticleimage" runat="server" Value="" />
                    <script type="text/javascript">
                        function readFile() {

                            document.querySelector("#imagArticlePreview").src = "";

                            if (!this.files || !this.files[0]) return;

                            const FR = new FileReader();

                            FR.addEventListener("load", function (evt) {
                                document.querySelector("#<%=hdnarticleimage.ClientID%>").value = evt.target.result;
                                document.querySelector("#imagArticlePreview").src = evt.target.result;
                                //document.querySelector("#b64").textContent = evt.target.result;
                            });

                            FR.readAsDataURL(this.files[0]);

                        }

                        document.querySelector("#fileArticleImage").addEventListener("change", readFile);
                    </script>
                </div>

            </div>

            <div class="row">

                <div class="col-sm-12">
                    &nbsp;
                </div>

            </div>

            <div class="row">

                <div class="col-sm-12 text-center">
                    <asp:Button ID="btnAdd" Text="Add" CssClass="btn btn-danger" runat="server" OnClick="btnAdd_Click" />
                </div>

            </div>


            <div class="row">

                <div class="col-sm-12">
                    &nbsp;
                </div>

            </div>

        </div>
    </form>
</body>
</html>
