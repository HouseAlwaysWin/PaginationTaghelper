using System;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Collections.Generic;
using GenericTagHelper.MethodHelpers;
using PaginationTagHelper.Pagination;

namespace PaginationTagHelper
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
        public IUrlHelper urlHelper
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

        #region Main Properties
        public int ItemPerPage { get; set; } = 5;

        public int CurrentPage { get; set; } = 1;

        public int TotalItems { get; set; }

        private int TotalPages
        {
            get
            {
                if (ItemPerPage <= 0)
                {
                    ItemPerPage = 5;
                }
                return (int)Math.Ceiling((decimal)
                    TotalItems / ItemPerPage);
            }
        }

        public string CurrentPageParameter { get; set; } = "page";
        public string PageQueryOptions { get; set; }
        private Dictionary<string, string> QueryOptions
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(PageQueryOptions);
            }
        }
        private Dictionary<string, string> QueryListDict { get; set; } = new Dictionary<string, string>();

        public string PageAction { get; set; } = "";

        public string PageController { get; set; } = "";
        #endregion

        #region Pagination Tag 
        public string TagPagination { get; set; } = "nav";

        public string TagPageGroup { get; set; } = "ul";
        public string AttrsPageGroup { get; set; } = "";
        public Dictionary<string, string> AttrsPageGroupDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageGroup);
            }
        }

        public string TagPageList { get; set; } = "li";
        public string AttrsPageList { get; set; } = "";
        public Dictionary<string, string> AttrsPageListDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageList);
            }
        }

        public string TagPageLink { get; set; } = "a";
        public string AttrsPageLink { get; set; } = "";
        public Dictionary<string, string> AttrsPageLinkDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageLink);
            }
        }

        public string TagPageIcon { get; set; } = "span";
        public string AttrsPageIcon { get; set; } = "";
        private Dictionary<string, string> AttrsPageIconDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageIcon);
            }
        }

        #endregion

        #region First Page Attributes 
        public string AttrsPageFirst { get; set; }
        private Dictionary<string, string> AttrsPageFirstDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageFirst);
            }
        }

        public string AttrsPageFirstLink { get; set; }
        private Dictionary<string, string> AttrsPageFirstLinkDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageFirstLink);
            }
        }

        public string AttrsPageFirstIcon { get; set; }
        private Dictionary<string, string> AttrsPageFirstIconDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageFirstIcon);
            }
        }
        public string PageFirstIcon { get; set; } = "First";

        #endregion

        #region Last Page Attributes
        public string AttrsPageLast { get; set; } = "";
        private Dictionary<string, string> AttrsPageLastDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageLast);
            }
        }


        public string AttrsPageLastLink { get; set; }
        private Dictionary<string, string> AttrsPageLastLinkDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageLastLink);
            }
        }

        public string AttrsPageLastIcon { get; set; }
        private Dictionary<string, string> AttrsPageLastIconDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageLastIcon);
            }
        }
        public string PageLastIcon { get; set; } = "Last";
        #endregion

        #region Previous Page Attributes
        public string AttrsPagePrevious { get; set; }
        private Dictionary<string, string> AttrsPagePreviousDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPagePrevious);
            }
        }


        public string AttrsPagePreviousLink { get; set; }
        private Dictionary<string, string> AttrsPagePreviousLinkDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPagePreviousLink);
            }
        }

        public string AttrsPagePreviousIcon { get; set; }
        private Dictionary<string, string> AttrsPagePreviousIconDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPagePreviousIcon);
            }
        }
        public string PagePreviousIcon { get; set; } = "Previous";
        #endregion

        #region Next Page Attributes
        public string AttrsPageNext { get; set; }
        private Dictionary<string, string> AttrsPageNextDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageNext);
            }
        }

        public string AttrsPageNextLink { get; set; }
        private Dictionary<string, string> AttrsPageNextLinkDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageNextLink);
            }
        }

        public string AttrsPageNextIcon { get; set; }
        private Dictionary<string, string> AttrsPageNextIconDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageNextIcon);
            }
        }
        public string PageNextIcon { get; set; } = "Next";
        #endregion

        #region Between Page Attributes
        public string AttrsPageBetween { get; set; }
        private Dictionary<string, string> AttrsPageBetweenDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageBetween);
            }
        }

        public string AttrsPageBetweenIcon { get; set; }
        private Dictionary<string, string> AttrsPageBetweenIconDict
        {
            get
            {
                return JsonDeserialize.JsonDeserializeConvert_Dss(AttrsPageBetweenIcon);
            }
        }
        public string PageBetweenIcon { get; set; } = "...";
        #endregion

        #region Other Properties
        public string PageActiveClass { get; set; } = "active";

        public string PageDisableClass { get; set; } = "disabled";

        public int PageMiddleLength { get; set; } = 2;

        public int PageTopBottomLength { get; set; } = 5;

        public bool PageShowFirst { get; set; } = true;

        public bool PageShowLast { get; set; } = true;

        public bool PageShowBetween { get; set; } = true;

        public bool PageExchangePreviousFirstBtn { get; set; }

        public bool PageExchangeNextLastBtn { get; set; }
        #endregion

        public override void Process(
            TagHelperContext context, TagHelperOutput output)
        {
            if (TotalPages <= 1)
            {
                return;
            }

            // <ul class="pagination"></ul>
            TagBuilder ul = new TagBuilder(TagPageGroup);
            // Set ul default class
            ul.Attributes["class"] = "pagination";
            HtmlAttributesHelper.AddAttributes(ul, AttrsPageGroupDict);

            // Show Middle Page Button
            for (int i = 1; i <= TotalPages; ++i)
            {
                var originPageList = AttrsPageList;
                if (!String.IsNullOrWhiteSpace(AttrsPageList))
                {
                    AttrsPageList = AttrsPageList.Replace("*", i.ToString());
                }

                var originPageLink = AttrsPageLink;
                if (!String.IsNullOrWhiteSpace(AttrsPageLink))
                {
                    AttrsPageLink = AttrsPageLink.Replace("*", i.ToString());
                }

                var originPageIcon = AttrsPageIcon;
                if (!String.IsNullOrWhiteSpace(AttrsPageLink))
                {
                    AttrsPageIcon = AttrsPageIcon.Replace("*", i.ToString());
                }


                TagBuilder list_li = PageButton(
                    has_link: true,
                    page_action: i,
                    icon: i.ToString(),
                    is_disabled: false,
                    active_page: i == CurrentPage,
                    page_type: "");

                if (AttrsPageListDict.Count != 0)
                {

                    HtmlAttributesHelper.AddAttributes(
                        list_li, AttrsPageListDict);
                }

                TagBuilder first_li = PageButton(
                    has_link: CurrentPage > 1,
                    page_action: i,
                    icon: PageFirstIcon,
                    is_disabled: CurrentPage == 1,
                    active_page: false,
                    page_type: "first");

                if (AttrsPageFirstDict.Count != 0)
                {
                    HtmlAttributesHelper.AddAttributes(
                        first_li, AttrsPageFirstDict);
                }

                TagBuilder last_li = PageButton(
                    has_link: CurrentPage < TotalPages,
                    page_action: i,
                    icon: PageLastIcon,
                    is_disabled: CurrentPage == TotalPages,
                    active_page: false,
                    page_type: "last");

                if (AttrsPageLastDict.Count != 0)
                {
                    HtmlAttributesHelper.AddAttributes(
                        last_li, AttrsPageLastDict);
                }

                TagBuilder dot_li = PageButton(
                    has_link: false,
                    page_action: i,
                    icon: PageBetweenIcon,
                    is_disabled: true,
                    active_page: false,
                    page_type: "between");

                if (AttrsPageBetweenDict.Count != 0)
                {
                    HtmlAttributesHelper.AddAttributes(
                        dot_li, AttrsPageBetweenDict);
                }

                /*-----------------------Show First and Previous Page Button-------------------------*/

                // Show previous and first btn in different location
                if (PageExchangePreviousFirstBtn)
                {
                    // Show First Page Btn
                    if (i == 1 && PageShowFirst)
                    {
                        ul.InnerHtml.AppendHtml(first_li);
                    }

                    // Show Previous Page Btn
                    if (i == 1)
                    {
                        var pre_li = PageButton(
                            has_link: (CurrentPage - 1) >= 1,
                            page_action: CurrentPage - 1,
                            icon: PagePreviousIcon,
                            is_disabled: CurrentPage == 1,
                            active_page: false,
                            page_type: "previous");

                        if (AttrsPagePreviousDict.Count != 0)
                        {
                            HtmlAttributesHelper.AddAttributes(
                                pre_li, AttrsPagePreviousDict);
                        }

                        ul.InnerHtml.AppendHtml(pre_li);
                        // if current page is bigger than 3 
                        // TotalPage can't be same as PageMiddleLength 
                        if (CurrentPage > PageMiddleLength + 1 &&
                            TotalPages > (1 + PageMiddleLength * 2) &&
                            PageShowBetween)
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
                            has_link: (CurrentPage - 1) >= 1,
                            page_action: CurrentPage - 1,
                            icon: PagePreviousIcon,
                            is_disabled: CurrentPage == 1,
                            active_page: false,
                            page_type: "previous");

                        if (AttrsPagePreviousDict.Count != 0)
                        {
                            HtmlAttributesHelper.AddAttributes(
                                pre_li, AttrsPagePreviousDict);
                        }

                        ul.InnerHtml.AppendHtml(pre_li);
                    }

                    // Show First Page
                    if (i == 1 && PageShowFirst)
                    {
                        ul.InnerHtml.AppendHtml(first_li);
                        // if current page is bigger than 3 
                        if (CurrentPage > PageMiddleLength + 1 &&
                            TotalPages > (1 + PageMiddleLength * 2) &&
                            PageShowBetween)
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
                    i >= CurrentPage - PageMiddleLength)
                {
                    checkPageRepeated = false;
                    ul.InnerHtml.AppendHtml(list_li);
                }



                // Show page number after bottom and top pages
                // which is middle pages
                if (i > PageTopBottomLength &&
                    i <= TotalPages - PageTopBottomLength &&
                    i >= CurrentPage - PageMiddleLength &&
                    i <= CurrentPage + PageMiddleLength)
                {
                    ul.InnerHtml.AppendHtml(list_li);
                }

                // Show page larger than total page -5,
                // if current page in the top then show 5 pages
                // and total pages must be bigger than 5
                if (i > TotalPages - PageTopBottomLength &&
                    i <= CurrentPage + PageMiddleLength &&
                    checkPageRepeated)
                {
                    ul.InnerHtml.AppendHtml(list_li);
                }


                /*-----------------------Show Next And Last Page Button-------------------------*/


                if (PageExchangeNextLastBtn)
                {
                    // Show Next Page Btn 
                    if (i == TotalPages)
                    {
                        var next_li = PageButton(
                            has_link: (CurrentPage + 1) <= TotalPages,
                            page_action: CurrentPage + 1,
                            icon: PageNextIcon,
                            is_disabled: CurrentPage == TotalPages,
                            active_page: false,
                            page_type: "next");

                        if (AttrsPageNextDict.Count != 0)
                        {
                            HtmlAttributesHelper.AddAttributes(
                                next_li, AttrsPageNextDict);
                        }

                        // if current page is smaller than total page minus five 
                        if ((CurrentPage < TotalPages - PageMiddleLength) &&
                            TotalPages > (1 + PageMiddleLength * 2)
                            && PageShowBetween)
                        {
                            ul.InnerHtml.AppendHtml(dot_li);
                        }

                        ul.InnerHtml.AppendHtml(next_li);
                    }

                    // Show Last Page Btn
                    if (i == TotalPages && PageShowLast)
                    {
                        ul.InnerHtml.AppendHtml(last_li);
                    }

                }
                else
                {
                    // Show Last Page Btn
                    if (i == TotalPages && PageShowLast)
                    {
                        // if current page is smaller than total page minus five 
                        if ((CurrentPage < TotalPages - PageMiddleLength) &&
                            TotalPages > (1 + PageMiddleLength * 2) &&
                            PageShowBetween)
                        {
                            ul.InnerHtml.AppendHtml(dot_li);
                        }

                        ul.InnerHtml.AppendHtml(last_li);
                    }

                    // Show Next Page Btn
                    if (i == TotalPages)
                    {
                        var next_li = PageButton(
                            has_link: (CurrentPage + 1) <= TotalPages,
                            page_action: CurrentPage + 1,
                            icon: PageNextIcon,
                            is_disabled: CurrentPage == TotalPages,
                            active_page: false,
                            page_type: "next");

                        if (AttrsPageNextDict.Count != 0)
                        {
                            HtmlAttributesHelper.AddAttributes(
                                next_li, AttrsPageNextDict);
                        }

                        ul.InnerHtml.AppendHtml(next_li);
                    }

                    AttrsPageList = originPageList;
                    AttrsPageLink = originPageLink;
                    AttrsPageIcon = originPageIcon;
                }

            }

            output.TagName = TagPagination;
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Content.SetHtmlContent(ul);

        }

        #region Helper method
        // Show Page Icon
        // <span aria-hidden="true">{{ icon  }}</span>
        public TagBuilder PageIcon(string icon, string page_type)
        {
            TagBuilder span = new TagBuilder(TagPageIcon);
            switch (page_type)
            {
                case "first":
                    span.Attributes["aria-hidden"] = "true";
                    HtmlAttributesHelper.AddAttributes(span, AttrsPageFirstIconDict);
                    span.InnerHtml.AppendHtml(icon);
                    break;
                case "last":
                    span.Attributes["aria-hidden"] = "true";
                    HtmlAttributesHelper.AddAttributes(span, AttrsPageLastIconDict);
                    span.InnerHtml.AppendHtml(icon);
                    break;
                case "previous":
                    span.Attributes["aria-hidden"] = "true";
                    HtmlAttributesHelper.AddAttributes(span, AttrsPagePreviousIconDict);
                    span.InnerHtml.AppendHtml(icon);
                    break;
                case "next":
                    span.Attributes["aria-hidden"] = "true";
                    HtmlAttributesHelper.AddAttributes(span, AttrsPageNextIconDict);
                    span.InnerHtml.AppendHtml(icon);
                    break;
                case "between":
                    span.Attributes["aria-hidden"] = "true";
                    HtmlAttributesHelper.AddAttributes(span, AttrsPageBetweenIconDict);
                    span.InnerHtml.AppendHtml(icon);
                    break;
                default:
                    span.Attributes["aria-hidden"] = "true";
                    HtmlAttributesHelper.AddAttributes(span, AttrsPageIconDict);
                    span.InnerHtml.AppendHtml(icon);
                    break;
            }

            return span;
        }

        // Show Page Link
        // <a href="/action?query"></a>
        public TagBuilder PageLink(
            TagBuilder a,
            int page_action)
        {
            if (!String.IsNullOrEmpty(PageQueryOptions))
            {
                foreach (var item in QueryOptions)
                {
                    try
                    {
                        QueryListDict[item.Key] = item.Value;
                    }
                    catch (ArgumentException)
                    {

                    }
                }
            }

            QueryListDict[CurrentPageParameter] = page_action.ToString();

            if (String.IsNullOrWhiteSpace(PageController))
            {

                a.Attributes["href"] = urlHelper.Action(
                     PageAction, QueryListDict);
            }
            else
            {
                a.Attributes["href"] = urlHelper.Action(
                                     PageAction, PageController,
                                     QueryListDict);
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
            bool active_page,
            string page_type)
        {
            TagBuilder li = new TagBuilder(TagPageList);
            TagBuilder a = new TagBuilder(TagPageLink);
            switch (page_type)
            {
                case "first":
                    a.Attributes["aria-label"] = icon;
                    HtmlAttributesHelper.AddAttributes(a, AttrsPageFirstLinkDict);
                    break;
                case "last":
                    a.Attributes["aria-label"] = icon;
                    HtmlAttributesHelper.AddAttributes(a, AttrsPageLastLinkDict);
                    break;
                case "previous":
                    a.Attributes["aria-label"] = icon;
                    HtmlAttributesHelper.AddAttributes(a, AttrsPagePreviousLinkDict);
                    break;
                case "next":
                    a.Attributes["aria-label"] = icon;
                    HtmlAttributesHelper.AddAttributes(a, AttrsPageNextLinkDict);
                    break;
                default:
                    a.Attributes["aria-label"] = icon;
                    HtmlAttributesHelper.AddAttributes(a, AttrsPageLinkDict);
                    break;
            }

            if (has_link)
            {
                a = PageLink(a, page_action);
            }

            a.InnerHtml.AppendHtml(PageIcon(icon, page_type));
            li.InnerHtml.AppendHtml(a);

            if (is_disabled)
            {
                li.Attributes["class"] = PageDisableClass;
            }

            if (active_page)
            {
                a.Attributes["class"] = PageActiveClass;
                li.Attributes["class"] = PageActiveClass;
            }

            return li;
        }
        #endregion
    }
}
