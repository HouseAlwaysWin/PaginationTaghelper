using System;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Routing;

namespace PaginationTaghelper
{
    [HtmlTargetElement("pagination")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;


        public PaginationTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        [HtmlAttributeNotBound]
        private IUrlHelper urlHelper
        {
            get
            {
                return urlHelperFactory.GetUrlHelper(ViewContext);
            }
        }

        // Get Current ViewContext
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }


        /*-----------------------Must Be Fullfill-------------------------*/
        public IQueryObject QueryModel { get; set; }

        public IPagingObject PagingModel { get; set; }

        public bool ActiveCustomQueryOptions { get; set; } = false;

        public dynamic QueryOptions { get; set; }

        public int TotalItems { get; set; }

        [HtmlAttributeNotBound]
        private int TotalPages
        {
            get
            {
                if (PagingModel.ItemPerPage <= 0)
                {
                    PagingModel.ItemPerPage = 5;
                }
                return (int)Math.Ceiling((decimal)
                    TotalItems / PagingModel.ItemPerPage);
            }
        }

        public string PageAction { get; set; }

        /*-----------------------Options-------------------------*/
        public string PageStyleClass { get; set; } = "pagination";

        public string ActivateClass { get; set; } = "active";

        public string DisableClass { get; set; } = "disabled";

        public int PageMiddleLength { get; set; } = 2;

        public int PageTopBottomLength { get; set; } = 5;

        public string PreviousIcon { get; set; } = "Previous";

        public string NextIcon { get; set; } = "Next";

        public string FirstIcon { get; set; } = "First";

        public string LastIcon { get; set; } = "Last";

        public bool ShowFirstPage { get; set; } = true;

        public bool ShowLastPage { get; set; } = true;

        public string BetweenIcon { get; set; } = "...";

        public bool ShowBetweenIcon { get; set; } = true;

        public bool ExchangePreviousFirstBtn { get; set; }

        public bool ExchangeNextLastBtn { get; set; }

        public bool ActiveSearchPage { get; set; }

        public override void Process(
            TagHelperContext context, TagHelperOutput output)
        {
            if (TotalPages <= 1)
            {
                return;
            }

            // <ul class="pagination"></ul>
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass(PageStyleClass);

            // Show Middle Page Button
            for (int i = 1; i <= TotalPages; ++i)
            {

                TagBuilder list_li = PageButton(
                    has_link: true,
                    page_action: i,
                    icon: i.ToString(),
                    is_disabled: false,
                    active_page: i == PagingModel.Page);

                TagBuilder first_li = PageButton(
                    has_link: PagingModel.Page > 1,
                    page_action: i,
                    icon: FirstIcon,
                    is_disabled: PagingModel.Page == 1,
                    active_page: false);

                TagBuilder last_li = PageButton(
                    has_link: PagingModel.Page < TotalPages,
                    page_action: i,
                    icon: LastIcon,
                    is_disabled: PagingModel.Page == TotalPages,
                    active_page: false);

                TagBuilder dot_li = PageButton(
                    has_link: false,
                    page_action: i,
                    icon: BetweenIcon,
                    is_disabled: true,
                    active_page: false);

                /*-----------------------Show First and Previous Page Button-------------------------*/

                // Show previous and first btn in different location
                if (ExchangePreviousFirstBtn)
                {
                    // Show First Page Btn
                    if (i == 1 && ShowFirstPage)
                    {
                        ul.InnerHtml.AppendHtml(first_li);
                    }

                    // Show Previous Page Btn
                    if (i == 1)
                    {
                        var pre_li = PageButton(
                            has_link: (PagingModel.Page - 1) >= 1,
                            page_action: PagingModel.Page - 1,
                            icon: PreviousIcon,
                            is_disabled: PagingModel.Page == 1,
                            active_page: false);

                        ul.InnerHtml.AppendHtml(pre_li);
                        // if current page is bigger than 3 
                        // TotalPage can't be same as PageMiddleLength 
                        if (PagingModel.Page > PageMiddleLength + 1 &&
                            TotalPages > (1 + PageMiddleLength * 2) &&
                            ShowBetweenIcon)
                        {
                            ul.InnerHtml.AppendHtml(dot_li);
                        }
                    }
                }
                else
                {
                    // Show Previous Btn
                    if (i == 1)
                    {
                        var pre_li = PageButton(
                            has_link: (PagingModel.Page - 1) >= 1,
                            page_action: PagingModel.Page - 1,
                            icon: PreviousIcon,
                            is_disabled: PagingModel.Page == 1,
                            active_page: false);

                        ul.InnerHtml.AppendHtml(pre_li);
                    }

                    // Show First Page
                    if (i == 1 && ShowFirstPage)
                    {
                        ul.InnerHtml.AppendHtml(first_li);
                        // if current page is bigger than 3 
                        if (PagingModel.Page > PageMiddleLength + 1 &&
                            TotalPages > (1 + PageMiddleLength * 2) &&
                            ShowBetweenIcon)
                        {
                            ul.InnerHtml.AppendHtml(dot_li);
                        }
                    }

                }


                /*-----------------------Middle Page Button-------------------------*/

                // Check if bottom page length is override to top page length
                // and only show page once.
                bool checkPageRepeated = true;
                // Show Middle Pages
                // if current page in the bottom then show 5 pages
                // Show pages less than 5 && show pages if bigger than current page-3

                if (i <= PageTopBottomLength &&
                    i >= PagingModel.Page - PageMiddleLength)
                {
                    checkPageRepeated = false;
                    ul.InnerHtml.AppendHtml(list_li);
                }



                // Show page number after bottom and top pages
                // which is middle pages
                if (i > PageTopBottomLength &&
                    i <= TotalPages - PageTopBottomLength &&
                    i >= PagingModel.Page - PageMiddleLength &&
                    i <= PagingModel.Page + PageMiddleLength)
                {
                    ul.InnerHtml.AppendHtml(list_li);
                }

                // Show page larger than total page -5,
                // if current page in the top then show 5 pages
                // and total pages must be bigger than 5
                if (i > TotalPages - PageTopBottomLength &&
                    i <= PagingModel.Page + PageMiddleLength &&
                    checkPageRepeated)
                {
                    ul.InnerHtml.AppendHtml(list_li);
                }


                /*-----------------------Show Next And Last Page Button-------------------------*/


                if (ExchangeNextLastBtn)
                {
                    // Show Next Page Btn 
                    if (i == TotalPages)
                    {
                        var next_li = PageButton(
                            has_link: (PagingModel.Page + 1) <= TotalPages,
                            page_action: PagingModel.Page + 1,
                            icon: NextIcon,
                            is_disabled: PagingModel.Page == TotalPages,
                            active_page: false);
                        // if current page is smaller than total page minus five 
                        if ((PagingModel.Page < TotalPages - PageMiddleLength) &&
                            TotalPages > (1 + PageMiddleLength * 2)
                            && ShowBetweenIcon)
                        {
                            ul.InnerHtml.AppendHtml(dot_li);
                        }

                        ul.InnerHtml.AppendHtml(next_li);
                    }

                    // Show Last Page Btn
                    if (i == TotalPages && ShowLastPage)
                    {
                        ul.InnerHtml.AppendHtml(last_li);
                    }

                }
                else
                {
                    // Show Last Page Btn
                    if (i == TotalPages && ShowLastPage)
                    {
                        // if current page is smaller than total page minus five 
                        if ((PagingModel.Page < TotalPages - PageMiddleLength) &&
                            TotalPages > (1 + PageMiddleLength * 2) &&
                            ShowBetweenIcon)
                        {
                            ul.InnerHtml.AppendHtml(dot_li);
                        }

                        ul.InnerHtml.AppendHtml(last_li);
                    }

                    // Show Next Page Btn
                    if (i == TotalPages)
                    {
                        var next_li = PageButton(
                            has_link: (PagingModel.Page + 1) <= TotalPages,
                            page_action: PagingModel.Page + 1,
                            icon: NextIcon,
                            is_disabled: PagingModel.Page == TotalPages,
                            active_page: false);


                        ul.InnerHtml.AppendHtml(next_li);
                    }
                }

            }


            output.TagName = "nav";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Content.SetHtmlContent(ul);

        }


        // Show Page Icon
        // <span aria-hidden="true">{{ icon  }}</span>
        public TagBuilder PageIcon(string icon)
        {
            TagBuilder span = new TagBuilder("span");
            span.MergeAttribute("aria-hidden", "true");
            span.InnerHtml.AppendHtml(icon);
            return span;
        }

        // Show Page Link
        // <a href="/action?query"></a>
        public TagBuilder PageLink(
            TagBuilder a,
            int page_action)
        {
            if (ActiveCustomQueryOptions)
            {
                // custom query link
                QueryOptions.page = page_action;

                a.Attributes["href"] = urlHelper.Action(
                    PageAction, (object)QueryOptions);
            }
            else
            {
                // default query link
                a.Attributes["href"] = urlHelper.Action(
                     PageAction, new
                     {
                         page = page_action,
                         searchby = QueryModel.SearchBy,
                         searchItem = QueryModel.SearchItem,
                         sortby = QueryModel.SortBy,
                         isSortAscending = QueryModel.IsSortAscending
                     });
            }


            return a;
        }

        // Show Page Button
        // <li disabled>
        //  <a aria-label="{{ icon }}" herf="">
        //      <span>{{ icon }}</span>
        //  </a>
        // </li>
        public TagBuilder PageButton(
            bool has_link,
            int page_action,
            string icon,
            bool is_disabled,
            bool active_page)
        {
            TagBuilder li = new TagBuilder("li");
            TagBuilder a = new TagBuilder("a");

            a.Attributes["aria-label"] = icon;

            if (has_link)
            {
                a = PageLink(a, page_action);
            }

            a.InnerHtml.AppendHtml(PageIcon(icon));
            li.InnerHtml.AppendHtml(a);

            if (is_disabled)
            {
                li.AddCssClass(DisableClass);
            }

            if (active_page)
            {
                a.AddCssClass(ActivateClass);
                li.AddCssClass(ActivateClass);
            }

            return li;
        }
    }
}
