# PaginationTaghelper

<h2>Requisition</h2>
Asp.Net Core 1.0 or above
<h2>Installation</h3>

From Package-Manager <strong><em>Install-Package PaginationTaghelper</em></strong>
<br/>
From .NET-CLI <strong><em>dotnet add package PaginationTaghelper</em></strong>
<br/>

<h2>How To Use It</h2>

Add <strong><em>@addTagHelper PaginationTaghelper.Pagination.*,PaginationTaghelper</em></strong> to your import _ViewImports.cshtml
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
      <td><strong>Attribute</strong></td>
      <td><strong>Comment</strong></td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><strong>query-model</strong></td>
      <td>Object has implemented IQueryObject,Must be used when <strong><em>active-custom-query-options"</em> is false</strong></td>
    </tr>
   <tr>
      <td><strong>paging-model</strong></td>
      <td>Object has implemented IPagingObject</td>
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
<br/>

```html
<pagination query-model="@Model.QueryObj"
            paging-model="@Model.PagingObj"
            total-items="@Model.TotalItems"
            page-action="your current view action">
</pagination>
```

<hr/>

<h3>Optional attribute</h3>

<table>
  <thead>
    <tr>
      <td><strong>Attribute</strong></td>
      <td><strong>Description<strong></td>
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
      <td>Show page length with current page left and right,for example PageMiddleLength is 2 and current page is 7 then it will show 5 6 7 8 9 pages ,<strong>the default value is <em>2</em></strong></td>
    </tr>
    <tr>
      <td><strong>page-top-bottom-length</strong></td>
      <td>Show page length with bottom page and top page length,for example PageTopBottomLength is 5 and current page is 1 then it will show 1 2 3 4 5 pages ,<strong>the default value is <em>5</em></strong></td>
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

<br/>
<h3>Pagination tag with all attributes</h3>

```html
<pagination query-model="@Model.QueryObj"
            paging-model="@Model.PagingObj"
            total-items="@Model.TotalItems"
            page-action="your current view action"
            page-style-class="pagination" //default
            activate-class="active"       //default
            disable-class="disabled"      //default 
            page-middle-length="2"        //default
            page-top-bottom-length="5"    //default
            previous-icon="Previous"      //default
            next-icon="Next"              //default
            first-icon="First"            //default
            last-icon="Last"              //default
            show-first-page="true"        //default
            show-last-page="true"         //default
            between-icon="..."            //default
            show-between-icon="true"      //default
            exchange-previous-first-btn="false" //default
            exchange-next-last-btn="false" //default 
            >
</pagination>
```


Your pagination tag will generate html like this...

```html
<nav>
    <ul class="pagination"> // page-style-class
        <li>
            <a aria-label="Previous"> // previous-icon
                <span aria-hidden="true">Previous</span> // previous-icon
            </a>
        </li>
        <li>
            <a aria-label="First"> // first-icon
                <span aria-hidden="true">First</span> // first-icon
            </a>
        </li>
         <li>
            <a aria-label="..." href="/?page=17&amp;isSortAscending=False"> // between-icon
                <span aria-hidden="true">...</span> // between-icon
            </a>
        </li>
        <li class="activate"> // activate-class
            <a aria-label="5" class="active" href="/?page=5&amp;isSortAscending=False"> // activate-class
                <span aria-hidden="true">5</span>
            </a>
        </li>
        <li>
            <a aria-label="6" href="/?page=6&amp;isSortAscending=False">
                <span aria-hidden="true">6</span>
            </a>
        </li>
         <li>
            <a aria-label="7" href="/?page=7&amp;isSortAscending=False">
                <span aria-hidden="true">7</span>
            </a>
        </li>
         <li>
            <a aria-label="8" href="/?page=8&amp;isSortAscending=False">
                <span aria-hidden="true">8</span>
            </a>
        </li>
         <li>
            <a aria-label="9" href="/?page=9&amp;isSortAscending=False">
                <span aria-hidden="true">9</span>
            </a>
        </li>
        <li> 
            <a aria-label="..."> // between-icon
                <span aria-hidden="true">...</span> // between-icon
            </a>
        </li>
        <li>
            <a aria-label="last-icon" href="/?page=17&amp;isSortAscending=False"> // last-icon
                <span aria-hidden="true">Last</span> // last-icon
            </a>
        </li>
        <li>
            <a aria-label="next-icon" href="/?page=2&amp;isSortAscending=False"> // next-icon
                <span aria-hidden="true">Next</span> // next-icon
            </a>
        </li>
    </ul>
</nav>
```

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

<h3>Custom query attribue with pagination tag</h3>

```html
<pagination paging-model="@Model.PagingObj"
            total-items="@Model.TotalItems"
            active-custom-query-options="true" // must be true
            query-options="@Model.QueryOptions"
            page-action="CustomQuery">
</pagination>
```

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

<hr/>
<h2>PaginationTaghelper offer three IQueryable Extension methods to help you building with pagination</h2>
<table>
 <thead>
  <tr>
   <td><strong>Extension></strong></td>
   <td><strong>Comment</strong></td>
  </tr>
 </thead>
 <tbody>
  <tr>
  <td><strong>ApplySearching</strong></td>
   <td>With two parameter,first is your query list,and second is your search map which you must add your custom search method<T></td>
  </tr>
  <tr>
  <td><strong>ApplyOrdering</strong></td>
   <td>With two parameter,first is your query list,and second is your sorted map</td>
  </tr>
  <tr>
  <td><strong>ApplyPaging</strong></td>
   <td>With one parameter IPagingObject</td>
  </tr>
 </tbody>
</table>

<h3>Please look at PaginationTaghelperExample for more implementation details</h3>
