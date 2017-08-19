# PaginationTaghelper


<h2>Installation</h3>

From Package-Manager <strong><em>Install-Package PaginationTaghelper</em></strong>
<br/>
From .NET-CLI <strong><em>dotnet add package PaginationTaghelper</em></strong>
<br/>

<br/>
<h2>How To Use It</h2>

Add <strong><em>@addTagHelper PaginationTaghelper.Pagination.*,PaginationTaghelper</em></strong> to your import _ViewImports.cshtml
<br/>
Add pagination tag in your view

<strong> \<pagination\>\</pagination\>
</strong>
<hr/>

And add attributes to tag

<h3>These attributes are must to be added</h3>
<table>
  <thead>
    <tr>
      <td><strong>Attribute</strong></td>
      <td><strong>Comment</strong></td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><strong>query-model</strong></td>
      <td>This is Instance implement from IQueryObject,Must be used whent active-custom-query-options is false</td>
    </tr>
   <tr>
      <td><strong>paging-model</strong></td>
      <td>This is Instance implement from IPagingObject</td>
    </tr>
    <tr>
      <td><strong>total-items</strong></td>
      <td>Total items from your list </td>
    </tr>
    <tr>
      <td><strong>page-action</strong></td>
      <td>Your current view's action</td>
    </tr>
  </tbody>
</table>

<hr/>

<h3>Optional attribute</h3>

<table>
  <thead>
    <tr>
      <td><strong>Attribute</strong></td>
      <td><strong>Comment<strong></td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><strong>page-style-class</strong></td>
      <td>Pagination's tag ul's class,default is pagination for bootstrap,<strong>the default is <em>pagination</em></strong></td>
    </tr>
    <tr>
      <td><strong>activate-class</strong></td>
      <td>Your current page active class,for bootstrap pagination is "active".other type pagination might be "current" or somethings,<strong>the default is <em>active</em></strong></td>
    </tr>
    <tr>
      <td><strong>disable-class</strong></td>
      <td>Your current page disabled class,for bootstrap pagination is "disabled".other type pagination might be empty or somethings,<strong>the default is <em>disabled</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-middle-length</strong></td>
      <td>Show page length between current page,for example PageMiddleLength is 2 and current page is 7 then it will show 5 6 7 8 9 pages ,<strong>the default value is <em>2</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-top-bottom-length</strong></td>
      <td>Show page length first page and last page length,for example PageTopBottomLength is 5 and current page is 1 then it will show 1 2 3 4 5 pages ,<strong>the default value is <em>5</em></strong></td>
    </tr>
    <tr>
      <td><strong>previous-icon</strong></td>
      <td>Show Previous Icon,It can be &laquo; or any string,<strong>the default is <em>Previous</em></strong></td>
    </tr>
    <tr>
      <td><strong>next-icon</strong></td>
      <td>Show Next Icon,It can be &raquo; or any string,<strong>the default is <em>Next</em></strong></td>
    </tr>
    <tr>
      <td><strong>first-icon</strong></td>
      <td>Show First Icon,It can be first number 1 or any string,<strong>the default is <em>First</em></strong></td>
    </tr>
    <tr>
      <td><strong>last-icon</strong></td>
      <td>Show Last Icon,It can be last number or any string,<strong>the default is <em>Last</em></strong></td>
    </tr>
    <tr>
      <td><strong>show-first-page</strong></td>
      <td>Show first page button or not,<strong>the default is <em>true</em></strong></td>
    </tr>
    <tr>
      <td><strong>show-last-page</strong></td>
      <td>Show Last page button or not,<strong> the default is <em>true</em></strong></td>
    </tr>
    <tr>
      <td><strong>between-icon</strong></td>
      <td>Show Between Icon,It can be ~ or any string,<strong>the default is <em>...</em></strong></td>
    </tr>
    <tr>
      <td><strong>show-between-icon</strong></td>
      <td>Show between page dot ... or not,<strong>the default is <em>true</em></strong></td>
    </tr>
    <tr>
      <td><strong>exchange-previous-first-btn</strong></td>
      <td>Exchange previous page button and first page button,<strong>the default is <em>false</em></strong></td>
    </tr>
    <tr>
      <td><strong>exchange-next-last-btn</strong></td>
      <td>Exchange next page button and last page button,<strong>the default is <em>false</em></strong></td>
    </tr>
  </tbody>
</table>

<hr/>

<h3>Custom Query attribute</h3>

<table>
  <thead>
    <tr>
      <td><strong>Attribute</strong></td>
      <td><strong>Comment</strong></td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><strong>active-custom-qery-options</strong></td>
      <td>Active to use customize query object,<strong>when active this you must add query-options attribute</strong>,and query-model is no need to use,<strong>the default is <em>false</em></strong></td>
    </tr>
     <tr>
      <td><strong>qery-options</strong></td>
      <td>Add customize query object,the object type must be ExpandoObject to dynamic binding query properies</td>
    </tr>
  </tbody>
</table>
<br/>

<hr/>

<h2>PaginationTaghelper offer three interfaces to help you building with pagination</h2>
<table>
 <thead>
  <tr>
   <td><strong>Interface</strong></td>
   <td><strong>Comment</strong></td>
   <td><strong>Properties</strong>
  </tr>
 </thead>
 <tbody>
  <tr>
   <td><strong>IPagingObject</strong></td>
   <td>For pagination this interface is must be implemented with your view model</td>
   <td><strong>Page,ItemPerPage</strong></td>
  </tr>
<tr>
   <td><strong>IQueryObject</strong></td>
   <td>For querying and make your pagination correct page this interface is must be implemented with your view model</td>
   <td><strong>SearchBy,SearchItem,SortBy,IsSortAscending,ShowAll</strong></td>
  </tr>
<tr>
   <td><strong>IPaginationViewModel<T><Customer></strong></td>
   <td>This generic abstract class is optional to your output view model,this interface is offering necessary properties to your pagination taghelper  </td>
   <td><strong>Items,TotalItems,QueryObj,PagingObj,QueryOptions</strong></td>
  </tr>
 </tbody>
</table>

<h3>Please look at PaginationTaghelperExample for more implementing details</h3>
