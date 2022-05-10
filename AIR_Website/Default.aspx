<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AIR_Website.Default" %>

<!DOCTYPE html>
<html>
<head>
<meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style>
body {font-family: Arial;}

.search-input  input[type=text] {
    width: 130px;
    box-sizing: border-box;
    border: 2px solid #ccc;
    border-radius: 4px;
    font-size: 16px;
    background-color: white;
    background-image: url('searchicon.png');
    background-position: 10px 10px; 
    background-repeat: no-repeat;
    padding: 12px 20px 12px 40px;
    -webkit-transition: width 0.4s ease-in-out;
    transition: width 0.4s ease-in-out;
}

.search-input  input[type=text]:focus {
    width: 50%;
}

/* Style the tab */
.tab {
    overflow: hidden;
    border: 1px solid #ccc;
    background-color: #f1f1f1;
}

/* Style the buttons inside the tab */
.tab button {
    background-color: inherit;
    float: left;
    border: none;
    outline: none;
    cursor: pointer;
    padding: 14px 16px;
    transition: 0.3s;
    font-size: 17px;
}

/* Change background color of buttons on hover */
.tab button:hover {
    background-color: #ddd;
}

/* Create an active/current tablink class */
.tab button.active {
    background-color: #ccc;
}

/* Style the tab content */
.tabcontent {
  //  display: none;
    padding: 6px 12px;
    -webkit-animation: fadeEffect 1s;
    animation: fadeEffect 1s;
}

/* Fade in tabs */
@-webkit-keyframes fadeEffect {
    from {opacity: 0;}
    to {opacity: 1;}
}

@keyframes fadeEffect {
    from {opacity: 0;}
    to {opacity: 1;}
}

//adding document
.container {
    padding: 20px;
    background-color: #f1f1f1;
}

.container  input[type=text], input[type=submit] {
    width: 80%;
    padding: 12px;
    margin: 8px 0;
    display: inline-block;
    border: 1px solid #ccc;
    box-sizing: border-box;
}

.container input[type=checkbox] {
    margin-top: 16px;
}

.container input[type=submit] {
    background-color: #4CAF50;
    color: white;
    border: none;
}

.container input[type=submit]:hover {
    opacity: 0.8;
}
//last search 
body {
    font-family: Arial;
}

* {
    box-sizing: border-box;
}

div.example input[type=text] {
    padding: 10px;
    font-size: 17px;
    border: 1px solid grey;
    float: left;
    width: 80%;
    background: #f1f1f1;
}

div.example button {
    float: left;
    width: 20%;
    padding: 10px;
    background: #2196F3;
    color: white;
    font-size: 17px;
    border: 1px solid grey;
    border-left: none;
    cursor: pointer;
}

div.example button:hover {
    background: #0b7dda;
}

div.example::after {
    content: "";
    clear: both;
    display: table;
}
.result{
    width:70%;
    margin:auto;
}
.result table tr{
    border-bottom:solid #9fadb7 ;
}
.result table{
    text-align:center;
    width:70%;
   // border:solid #9fadb7 ;
    border-collapse:collapse;
}
.result table tr th{
    text-align:center;
}
th{
    text-align:center;
}
.result tr td{
    text-align:left;
    vertical-align:top;
}
.result tr td:first-child{
    width:20%;
    border-right:solid #9fadb7;
}
th:first-child{
    border-right:solid #9fadb7;
}
</style>
</head>
<body>
    <form id="form" runat="server">


<div id="Search" class="tabcontent">
  <h3>Search</h3>
  <p>Booelean Searh type items to search in documents with ( <b>&</b> for <i>AND</i> , <b>|</b> for <i>Or</i> and for <i>Not</i> use <b>!</b> ,and brackets <i>(</i> and <i>)</i> ) .e.g. item1<b> & </b>item2 <b>|</b> ( ! <b></b>item3<b> )</b></p>

        <div class="example" >
            <input runat="server" id="txtSearch" type="text" placeholder="Search.." name="search">    
             <asp:Button ID="btnSearch" OnClick="btnSearch_Click"   runat="server" Text="Search" />
        </div>

       
        <h4>Search result</h4> 
        <div class="result">
            <asp:Literal ID="literalSearchResult" runat="server"></asp:Literal>
        </div>
      
</div>

<div id="Document" class="tabcontent">
  <h3>Document</h3>
     <div class="container">
    <h2>Document Information</h2>
    <p>Type your document's name and its content in fields below, then press index for indexing</p>
  </div>

  <div class="container" style="background-color:white">
    <input type="text" placeholder="Document name" name="name" runat="server" id="input_docName" >
    <input type="text" placeholder="Document text" runat="server" id="input_docText" name="documenttext" >

  </div>

  <div class="container">
      <asp:Button ID="btnIndex" OnClick="btnIndex_Click" runat="server" Text="Index" />
  </div>
     <h4>Indexing result</h4> 
   
        <div class="result">
        <asp:Literal ID="literalIndexResult" runat="server"></asp:Literal>
        </div>
   
</div>


     </form>
</body>
</html> 
