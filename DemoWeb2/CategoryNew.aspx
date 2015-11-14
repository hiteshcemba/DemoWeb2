<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryNew.aspx.cs" Inherits="DemoWeb2.CategoryNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function userValid() {
        var category = document.getElementById('<%=txtCategory.ClientID %>').value;
        var email = document.getElementById('<%=txtEmail.ClientID %>').value;
        if (category == '') {
            alert("Category Name is missing !");
            return false;
        }
        else if (email == '') 
        {
            alert("Email is missing !");
            return false;
        }
        var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/
        var EmailmatchArray = email.match(emailPat);
        if (EmailmatchArray == null) {
            alert("Email is not valid !");
            return false;

        }

             
     }
</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
       Create New Category
    </h2>
    <hr />
     <table>

     <tr>
     <td colspan=2>
     <asp:Label ID="lblerror" runat="server"  ForeColor="Red"></asp:Label>
     </td>
     </tr>
    <tr>
    <td> Category :   </td>
    <td> <asp:TextBox  ID="txtCategory" runat="server"  Width="150px"></asp:TextBox>   
 <!--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  
            ErrorMessage="Category is missing !" ControlToValidate="txtCategory" 
            ForeColor="Red"></asp:RequiredFieldValidator>-->
        </td>
    </tr>
     <tr>
    <td> Email :   </td>
    <td> <asp:TextBox  ID="txtEmail" runat="server"  Width="150px"></asp:TextBox>  
    <!-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  
            ErrorMessage="Email is missing !" ControlToValidate="txtEmail" 
            ForeColor="Red"></asp:RequiredFieldValidator> 
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txtEmail" ErrorMessage="Email address is not valid !" 
            ForeColor="Red" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>-->
        </td>
    </tr>
    <tr>
    <td>
    </td>
    <td >
    <asp:Button ID="btnsubmit" runat="server" Text ="Save" Width="104px" 
          OnClientClick = "return userValid()"    onclick="btnsubmit_Click" />
    </td>
    </tr>
    </table>
       
  
</asp:Content>
