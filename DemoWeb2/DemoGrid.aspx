<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DemoGrid.aspx.cs" Inherits="DemoWeb2.DemoGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
    Demo GridView
    </h2>
    <hr />
     <asp:Label ID="lblerror" runat="server"  ForeColor="Red"></asp:Label>
    <br />

 <asp:DataGrid ID="Grid" runat="server" PageSize="5" AllowPaging="True" DataKeyField="EmpId"
AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand"
OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand">
<Columns>
<asp:BoundColumn HeaderText="EmpId" DataField="EmpId">
</asp:BoundColumn>
<asp:BoundColumn HeaderText="F_Name" DataField="F_Name">
</asp:BoundColumn>
<asp:BoundColumn HeaderText="L_Name" DataField="L_Name">
</asp:BoundColumn>
<asp:BoundColumn DataField="City" HeaderText="City">
</asp:BoundColumn>
<asp:BoundColumn DataField="EmailId" HeaderText="EmailId">
</asp:BoundColumn>
<asp:BoundColumn DataField="EmpJoining" HeaderText="EmpJoining">
</asp:BoundColumn>
<asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" HeaderText="Edit">
</asp:EditCommandColumn>
<asp:ButtonColumn CommandName="Delete" HeaderText="Delete" Text="Delete">
</asp:ButtonColumn>
</Columns>
<FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
<SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
<PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />
<AlternatingItemStyle BackColor="White" />
<ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
<HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
</asp:DataGrid>
   
  
</asp:Content>
