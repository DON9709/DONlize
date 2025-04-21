using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DONlize.Utils
{
    public static class RevitElementUtils
    {
        // ✅ 이 메서드는 CategorySelectionForm에서 사용하는 방식
        public static List<Element> CollectElementsByCategories(Document doc, List<BuiltInCategory> categories)
        {
            var allElements = new List<Element>();

            foreach (var bic in categories)
            {
                var elements = new FilteredElementCollector(doc)
                    .OfCategory(bic)
                    .WhereElementIsNotElementType()
                    .ToList();

                allElements.AddRange(elements);
            }

            return allElements;
        }

        // ✅ 이 메서드도 CategorySelectionForm에서 필요
        public static Dictionary<Element, Dictionary<string, string>> ExtractParameterValues(List<Element> elements, List<string> paramNames)
        {
            var result = new Dictionary<Element, Dictionary<string, string>>();

            foreach (var elem in elements)
            {
                var paramDict = new Dictionary<string, string>();

                foreach (var paramName in paramNames)
                {
                    var param = elem.LookupParameter(paramName);
                    if (param != null)
                        paramDict[paramName] = param.AsValueString() ?? "";
                    else
                        paramDict[paramName] = "";
                }

                result[elem] = paramDict;
            }

            return result;
        }

        // 아래는 기존 코드 유지 (참고용)
        public static List<Element> GetElementsByCategory(Document doc, BuiltInCategory category)
        {
            return new FilteredElementCollector(doc)
                .OfCategory(category)
                .WhereElementIsNotElementType()
                .ToList();
        }

        public static List<string> GetParameterNamesFromElements(List<Element> elements)
        {
            HashSet<string> parameterNames = new HashSet<string>();

            foreach (var element in elements)
            {
                foreach (Parameter param in element.Parameters)
                {
                    if (param != null && param.Definition != null)
                    {
                        string name = param.Definition.Name;
                        parameterNames.Add(name);
                    }
                }
            }

            return parameterNames.OrderBy(name => name).ToList();
        }
    }
}
