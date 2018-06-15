<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AjaxCallXmlExample.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table ID="grdXml" style="width:100%">
    </table>

    <script type="text/javascript">

        $(document).ready(function () {
            BindGridView();
        });

        function BindGridView() {
            $.ajax({
                type: "GET",
                url: "https://test40-pa-dev01.uat.mymediabox.com/inbox/get-media-list-for-folder.xml?g4_ignoretransform=yes",
                dataType: "text",
                success: function (data) {
                    var parser, xmlDoc;
                    parser = new DOMParser();
                    xmlDoc = parser.parseFromString(data, "text/xml");

                    $("#grdXml").empty();
                    $("#grdXml").append('<tr><td>MediaID</td><td>ShortDescription</td><td>DateCreated</td><td>Title</td><td>FileSize</td></tr>');

                    let mediaNodeList = xmlDoc.getElementsByTagName("get-media-list-for-folder")
                    for (i = 0; i < mediaNodeList.length; i++) {
                        let mediaNode = mediaNodeList[i];

                        let media = new Object();
                        let mediaString = '<tr><td>'
                            + xmlGetValue(mediaNode, "MediaID") + '</td><td>'
                            + xmlGetValue(mediaNode, "ShortDescription") + '</td><td>'
                            + xmlGetValue(mediaNode, "DateCreated") + '</td><td>'
                            + xmlGetValue(mediaNode, "Title") + '</td><td>'
                            + xmlGetValue(mediaNode, "FileSize") + '</td></tr>';

                        $("#grdXml").append(mediaString);
                    }
                }
            });
        }

        function xmlGetValue(xmlNode, elementName) {
            return xmlNode.getElementsByTagName("MediaID")[0].childNodes[0].nodeValue;
        }
    </script>

</asp:Content>
