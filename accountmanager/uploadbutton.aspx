<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploadbutton.aspx.cs" Inherits="accountmanager.uploadbutton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
		<fieldset>
			<legend>
				...or hey upload a file!
			</legend>
    	<asp:FileUpload ID="Uploader" runat="server" />
    	<asp:Button ID="UploadSubmit" runat="server" OnClick="UploadSubmit_Click" Text="Upload" Height="40px" BackColor="White" BorderStyle="None" ForeColor="Blue" />
		</fieldset>
    <asp:Label ID="StatusLabel" runat="server" Font-Italic="True"></asp:Label>
		<br />
    </form>
	
</body>
</html>
