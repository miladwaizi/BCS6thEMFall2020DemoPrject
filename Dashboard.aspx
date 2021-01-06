<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BCS6thEMFall2020DemoPrject.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPageTitle" runat="server">
DASHBOARD
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPath" runat="server">
                <li id="test" class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a>
                </li>
                <li class="breadcrumb-item active">Home
                </li>  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentDescription" runat="server">
The graph and statistics shown over here...
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentBody" runat="server">

    <table class="table table-bordered table-hover">

        <tr>
            <th>S.NO</th>
            <th>Name</th>
        </tr>
        <tr>
            <td>1</td>
            <td>Ahmad</td>
        </tr>
        <tr>
            <td>2</td>
            <td>Sayed</td>
        </tr>
    </table>
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
