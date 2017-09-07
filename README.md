# PaginationTaghelper

<h2>Requirement</h2>
.NetStandard 1.6 or above
<h2>Installation</h3>

From Package-Manager <strong><em>Install-Package PaginationTaghelper</em></strong>
<br/>
From .NET-CLI <strong><em>dotnet add package PaginationTaghelper</em></strong>
<br/>

<h2>How To Use It</h2>

Add <strong><em>@addTagHelper PaginationTagHelper.*,PaginationTagHelper</em></strong> to your import _ViewImports.cshtml
<br/>
Add pagination tag in your view
``` html
<pagination></pagination>

```
<hr/>

And add attributes to tag

<h3>These attributes are must to be added</h3>
<table>
  <thead>
    <tr>
      <td><strong>Attributes</strong></td>
      <td><strong>Descriptions</strong></td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><strong>total-items</strong></td>
      <td>Your total items number</td>
    </tr>
   <tr>
      <td><strong>item-per-page</strong></td>
      <td>Show the number of items in your each page</td>
    </tr>
    <tr>
      <td><strong>current-page</strong></td>
      <td>Your current page of number, it's controled by your controller</b>
    </tr>
    <tr>
      <td><strong>page-action</strong></td>
      <td>Your current view's action</td>
    </tr>
    <tr>
      <td><strong>page-controller</strong></td>
      <td>Your current view's controller,not necessary when you use page-action attribute</td>
    </tr>
  </tbody>
</table>
<br/>

<h2>For Examlpe:</h2>

```html
<pagination total-items="@Model.TotalItems"
            item-per-page="@Model.ItemPerPage"
            current-page="@Model.Page"
            page-action="PageWithoutQuery"
            page-controller="Home">
</pagination>
```

<hr/>

<h2>Optional attributes</h2>

<h3>Change your tags</h3>

<table>
 <thead>
    <tr>
      <td><strong>Attributes</strong></td>
      <td><strong>Descriptions<strong></td>
    </tr>
  </thead>
   <tbody>
    <tr>
      <td><strong>tag-pagination</strong></td>
      <td>Change you pagination tag,<strong>the default is <em>nav</em></strong></td>
    </tr>
     <tr>
      <td><strong>tag-page-group</strong></td>
      <td>Change you page list group tag,<strong>the default is <em>ul</em></strong></td>
    </tr>
     <tr>
      <td><strong>tag-page-list</strong></td>
      <td>Change you page list item tag,<strong>the default is <em>li</em></strong></td>
    </tr>
     <tr>
      <td><strong>tag-page-link</strong></td>
      <td>Change you list item's link tag,<strong>the default is <em>a</em></strong></td>
    </tr>
     <tr>
      <td><strong>tag-page-icon</strong></td>
      <td>Change you link icon tag,<strong>the default is <em>span</em></strong></td>
    </tr>
    </tbody>
</table>

<hr/>
<br/>

<h3>Change your paging list attributes</h3>
<h4>Intruduction</h4>
Attribute property are all start with <strong>attrs-page-*.</strong>
<br/>
The attribute's contents are all use json format.
<h5>For Example</h5>
You want to add class="form-control" to attrs-page-link
the html will be like this:

```html
attrs-page-link='{
  class:"form-control"
'}
```

You can use "\*" to do the numbers of sequence in your attribute.
<h4>For example:</h4>

```html
attrs-page-list='{
  Id:"pagelink*"
'}
```

Will generate list id like this...

```html
<li id="pagelink1></li>
<li id="pagelink2></li>
<li id="pagelink3></li>
<li id="pagelink4></li>
<li id="pagelink5></li>
<li id="pagelink6></li>
```

<strong>note: the "\*" is only use in the paging list,not for single button or link.</strong>

<br/>

<table>
 <thead>
    <tr>
      <td><strong>Attributes</strong></td>
      <td><strong>Descriptions<strong></td>
    </tr>
  </thead>
   <tbody>
    <tr>
      <td><strong>attrs-page-group</strong></td>
      <td>Add attributes to your page-group list,<strong>the default has attribute <em>class="pagination"</em></strong></td>
    </tr>
     <tr>
      <td><strong>attrs-page-list</strong></td>
      <td>Add attributes to you page list item,<strong>the default is <em>empty</em></strong></td>
    </tr>
     <tr>
      <td><strong>attrs-page-link</strong></td>
      <td>Add attributes to your page list item,<strong>the default has <em>aria-label="your page number"</em></strong></td>
    </tr>
     <tr>
      <td><strong>attrs-page-icon</strong></td>
      <td>Add attributes to your list item's icon,<strong>the default is <em>aria-hidden="true"</em></strong></td>
    </tr>
    </tbody>
</table>

Under the code will show what tags will be changed with attributes.

```html
<ul> --> attrs-page-group will add attributes to this tag
  <li> --> attrs-page-list will add attributes to this tag
    <a href="pagelinks"> --> attrs-page-link will add attributes to this tag
      <span></span> --> attrs-page-icon will add attributes to this tag
    </a>
  <li>
</ul>
```

<hr/>

<h3>Add attribute your first page button</h3>
<table>
 <thead>
    <tr>
      <td><strong>Attributes</strong></td>
      <td><strong>Descriptions<strong></td>
    </tr>
  </thead>
   <tbody>
    <tr>
      <td><strong>attrs-page-first</strong></td>
      <td>Add attributes to your first page button</td>
    </tr>
     <tr>
      <td><strong>attrs-page-first-link</strong></td>
      <td>Add attributes to you first page button link</td>
    </tr>
     <tr>
      <td><strong>attrs-page-first-icon</strong></td>
      <td>Add attributes to your first page button icon</td>
    </tr>
    </tbody>
</table>

<hr/>

<h3>Add attribute your last page button</h3>
<table>
 <thead>
    <tr>
      <td><strong>Attributes</strong></td>
      <td><strong>Descriptions<strong></td>
    </tr>
  </thead>
   <tbody>
    <tr>
      <td><strong>attrs-page-last</strong></td>
      <td>Add attributes to your last page button</td>
    </tr>
     <tr>
      <td><strong>attrs-page-last-link</strong></td>
      <td>Add attributes to you last page button link</td>
    </tr>
     <tr>
      <td><strong>attrs-page-last-icon</strong></td>
      <td>Add attributes to your last page button icon</td>
    </tr>
    </tbody>
</table>

<hr/>

<h3>Add attribute your previous page button</h3>
<table>
 <thead>
    <tr>
      <td><strong>Attributes</strong></td>
      <td><strong>Descriptions<strong></td>
    </tr>
  </thead>
   <tbody>
    <tr>
      <td><strong>attrs-page-previous</strong></td>
      <td>Add attributes to your previous page button</td>
    </tr>
     <tr>
      <td><strong>attrs-page-previous-link</strong></td>
      <td>Add attributes to you previous page button link</td>
    </tr>
     <tr>
      <td><strong>attrs-page-previous-icon</strong></td>
      <td>Add attributes to your previous page button icon</td>
    </tr>
    </tbody>
</table>

<hr/>

<h3>Add attribute your next page button</h3>
<table>
 <thead>
    <tr>
      <td><strong>Attributes</strong></td>
      <td><strong>Descriptions<strong></td>
    </tr>
  </thead>
   <tbody>
    <tr>
      <td><strong>attrs-page-next</strong></td>
      <td>Add attributes to your next page button</td>
    </tr>
     <tr>
      <td><strong>attrs-page-next-link</strong></td>
      <td>Add attributes to you next page button link</td>
    </tr>
     <tr>
      <td><strong>attrs-page-next-icon</strong></td>
      <td>Add attributes to your next page button icon</td>
    </tr>
    </tbody>
</table>

<hr/>

<h3>Add attribute your between page icon</h3>
<table>
 <thead>
    <tr>
      <td><strong>Attributes</strong></td>
      <td><strong>Descriptions<strong></td>
    </tr>
  </thead>
   <tbody>
    <tr>
      <td><strong>attrs-page-between</strong></td>
      <td>Add attributes to your betweeb page button</td>
    </tr>
     <tr>
      <td><strong>attrs-page-between-icon</strong></td>
      <td>Add attributes to you between page button icon</td>
    </tr>
    </tbody>
</table>

<hr/>

<h3>Other optional properties</h3>

<table>
  <thead>
    <tr>
      <td><strong>Attributes</strong></td>
      <td><strong>Descriptions<strong></td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><strong>page-active-class</strong></td>
      <td>Your current page active class,for bootstrap pagination is "active".other type pagination might be "current" or somethings,<strong>the default is <em>active</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-disable-class</strong></td>
      <td>Your current page disabled class,for bootstrap pagination is "disabled".other type pagination might be empty or somethings,<strong>the default is <em>disabled</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-middle-length</strong></td>
      <td>Show page length with current page left and right,for example PageMiddleLength is 2 and current page is 7 then it will show 5 6 7 8 9 pages ,<strong>the default value is <em>2</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-top-bottom-length</strong></td>
      <td>Show page length with bottom page and top page length,for example PageTopBottomLength is 5 and current page is 1 then it will show 1 2 3 4 5 pages ,<strong>the default value is <em>5</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-previous-icon</strong></td>
      <td>Show Previous Icon,It can be &laquo; or any string,<strong>the default is <em>Previous</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-next-icon</strong></td>
      <td>Show Next Icon,It can be &raquo; or any string,<strong>the default is <em>Next</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-first-icon</strong></td>
      <td>Show First Icon,It can be first number 1 or any string,<strong>the default is <em>First</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-last-icon</strong></td>
      <td>Show Last Icon,It can be last number or any string,<strong>the default is <em>Last</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-show-first</strong></td>
      <td>Show first page button or not,<strong>the default is <em>true</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-show-last</strong></td>
      <td>Show Last page button or not,<strong> the default is <em>true</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-between-icon</strong></td>
      <td>Show Between Icon,It can be ~ or any string,<strong>the default is <em>...</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-show-between</strong></td>
      <td>Show between page dot ... or not,<strong>the default is <em>true</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-swap-previous-first-btn</strong></td>
      <td>Exchange previous page button and first page button,<strong>the default is <em>false</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-swap-next-last-btn</strong></td>
      <td>Exchange next page button and last page button,<strong>the default is <em>false</em></strong></td>
    </tr>
  </tbody>
</table>

<br/>

<hr/>

<h3>Custom Query attribute</h3>

<table>
  <thead>
    <tr>
      <td><strong>Attribute</strong></td>
      <td><strong>Description</strong></td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><strong>current-page-parameter</strong></td>
      <td>Add any strings what you want to use in your current page parameter,<strong>the default is <em>page</em><strong></td>
    </tr>
     <tr>
      <td><strong>page-qery-options</strong></td>
      <td>Add json format string to your query parameter, It can be direct used json string in your razor view or serialize your query from the controller.For more detail please see my examlpe</td>
    </tr>
  </tbody>
</table>
<br/>


<hr/>

<h2>PaginationTaghelper give you three interfaces to help you building with pagination</h2>
<table>
 <thead>
  <tr>
   <td><strong>Interface</strong></td>
   <td><strong>Descriptions</strong></td>
  </tr>
 </thead>
 <tbody>
  <tr>
   <td><strong>IPagingObject</strong></td>
   <td>For pagination this interface can implement in your model or view model to do paginations,it's optional interface</td>
  </tr>
<tr>
   <td><strong>IQueryObject</strong></td>
   <td>For querying this interface can implement in your model or view model to use in your query options,it's optional interface</td>
  </tr>
 </tbody>
</table>

<hr/>
<h2>PaginationTaghelper give you three IQueryable Extension methods to help you building with pagination</h2>
<table>
 <thead>
  <tr>
   <td><strong>Extension</strong></td>
   <td><strong>Descriptions</strong></td>
  </tr>
 </thead>
 <tbody>
  <tr>
  <td><strong>ToSearchByList</strong></td>
   <td>With two parameter,first is your search type,and second is your search item to map string what you have typed.</td>
  </tr>
  <tr>
  <td><strong>ToOrderByList</strong></td>
   <td>With two parameter,first is your sort type,and second is sort descending?</td>
  </tr>
  <tr>
  <td><strong>ToPageList</strong></td>
   <td>With two parameter,first is current page,second is your number of items per page.</td>
  </tr>
 </tbody>
</table>

<hr/>

<h3>For more example or details, please see my PaginationTagHelperExample</h3>
