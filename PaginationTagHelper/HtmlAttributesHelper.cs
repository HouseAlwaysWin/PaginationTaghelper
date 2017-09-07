using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericTagHelper.MethodHelpers
{
    public static class HtmlAttributesHelper
    {
        public static bool IsContainsKey(
           Dictionary<int, string> itemAttrs,
           string loopKey)
        {
            return itemAttrs.Any(d => d.Key.Equals(loopKey));
        }

        public static bool IsContainsKey(
            Dictionary<string, string> itemAttrs,
            string loopKey)
        {
            return itemAttrs.Any(d => d.Key.Equals(
                loopKey, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsContainsKey(
            Dictionary<string, Dictionary<string, string>> itemAttrs,
            string loopKey)
        {
            return itemAttrs.Any(item => item.Key.Equals(
                loopKey, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsContainsKey(
            Dictionary<string, List<Dictionary<string, string>>> dataDict,
            string loopKey)
        {
            return dataDict.Any(item => item.Key.Equals(
                loopKey, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsContainsKey(
            Dictionary<string, List<List<Dictionary<string, string>>>> dataDict,
            string loopKey)
        {
            return dataDict.Any(item => item.Key.Equals(
                loopKey, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsContainsKey(
            Dictionary<string, Dictionary<string, List<Dictionary<string, string>>>> dataDict,
            string loopKey)
        {
            return dataDict.Any(item => item.Key.Equals(
                loopKey, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsContainsKey(
            Dictionary<string, Dictionary<string, List<List<Dictionary<string, string>>>>> dataDict,
            string loopKey)
        {
            return dataDict.Any(item => item.Key.Equals(
                loopKey, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsContainsKey(
            Dictionary<string, List<Dictionary<string, List<List<Dictionary<string, string>>>>>> dataDict,
            string loopKey)
        {
            return dataDict.Any(item => item.Key.Equals(
                loopKey, StringComparison.OrdinalIgnoreCase));
        }

        public static void AddClass(
            TagBuilder tag,
            Dictionary<string, string> itemClass,
            string loopKey)
        {
            if (IsContainsKey(itemClass, loopKey) &&
                itemClass.Count != 0)
            {
                try
                {
                    tag.Attributes["class"] =
                        itemClass.LastOrDefault(
                            item => item.Key.Equals(loopKey,
                            StringComparison.OrdinalIgnoreCase)).Value;
                }
                catch (ArgumentException)
                {
                    return;
                }
            }
        }

        #region  Attributes
        public static void AddAttributes(
            TagBuilder tag,
            Dictionary<string, string> itemAttrs)
        {
            if (itemAttrs.Keys.Count != 0)
            {
                try
                {
                    itemAttrs.ToDictionary(attr =>
                    {
                        tag.Attributes[attr.Key] = attr.Value;

                        return tag;
                    });
                }
                catch (ArgumentException)
                {
                    return;
                }
            }
        }

        // For applying all tags's attributes
        public static void AddAttributes(
            TagBuilder tag,
            Dictionary<string, string> allItemsAttr,
            string loopKey)
        {
            if (allItemsAttr.Count != 0)
            {
                foreach (var attr in allItemsAttr)
                {
                    try
                    {
                        tag.Attributes[attr.Key] = attr.Value;
                    }
                    catch (ArgumentException)
                    {
                        return;
                    }
                }
            }
        }

        // For applying specific tag's attributes
        public static void AddAttributes(
            TagBuilder tag,
            Dictionary<string, Dictionary<string, string>> oneItemAttr,
            string loopKey)
        {
            if (IsContainsKey(oneItemAttr, loopKey) &&
                oneItemAttr.Count != 0)
            {

                // try catch if key is duplicated
                try
                {
                    oneItemAttr.LastOrDefault(
                    item => item.Key
                    .Equals(loopKey, StringComparison.OrdinalIgnoreCase))
                    .Value
                    .ToDictionary(attr =>
                    {
                        tag.Attributes[attr.Key] = attr.Value;
                        return tag;
                    });
                }
                catch (ArgumentException)
                {
                    return;
                }


            }
        }


        // For applying both type
        public static void AddAttributes(
            TagBuilder tag,
            Dictionary<string, string> allItemAttrs,
            Dictionary<string, Dictionary<string, string>> oneItemAttrs,
            string loopKey
            )
        {
            AddAttributes(tag, allItemAttrs, loopKey);
            AddAttributes(tag, oneItemAttrs, loopKey);
        }
        #endregion


    }
}
