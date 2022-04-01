using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebPerson
{
    public static class HTMLHelper
    {
        public static IHtmlContent MyEditorForModel(this IHtmlHelper helper) =>
            new FormContent(helper.ViewData.Model ?? helper.ViewData.ModelMetadata.ModelType
                .GetConstructor(Type.EmptyTypes)?.Invoke(Array.Empty<object>()));

        private class FormContent : IHtmlContent
        {
            public void WriteTo(TextWriter writer, HtmlEncoder encoder)
            {
                writer.WriteLine(_resultContent);
            }

            private readonly string _resultContent;

            public FormContent(object model) =>
                _resultContent = SetForm(model.GetType().GetProperties(), model);

            private static string SetForm(IEnumerable<PropertyInfo> property, object model) =>
                property
                    .Select(formElement =>
                        SetInputHeader(formElement) +
                        "<div class=\"editor-field\">" +
                        SetInputBody(formElement, model) +
                        "</div>")
                    .Aggregate(string.Concat)
                + $"<div class=\"form-group\"><input type = \"submit\" text=\"Submit\"/></div>";

            private static string SetInputHeader(PropertyInfo prop) =>
                    $"<div class=\"editor-label\">"
                    + $"<label for=\"{prop.Name}\">"
                    + (prop.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute)?.Name
                    + "</label></div>";

            private static string SetInputBody(PropertyInfo prop, object model) =>
                    SetInput(prop) + SetInputSpan(prop, model);

            private static string SetInput(PropertyInfo property) =>
                    property.PropertyType.IsAssignableTo(typeof(Enum))
                        ? "<select class=\"form-group\">"
                          + $"<option value=\"\" disabled selected>{property.Name}</option>"
                          + property.PropertyType
                              .GetFields()
                              .Where(x => x.Name != "value__")
                              .Select(option => $"<option value=\"{option.Name}\">{option.Name}</option>")
                              .Aggregate(string.Concat)
                          + "</select>"
                        : IsDigitType(property.PropertyType)
                            ? $"<input class=\"text-box single-line\" type=\"number\" name=\"{property.Name}\">"
                            : $"<input class=\"text-box single-line\" type=\"text\" name=\"{property.Name}\">";

            private static string SetInputSpan(PropertyInfo property, object model)
            {
                var output =
                    $"<span class=\"field-validation-error\" data-valmsg-for=\"{property.Name}\" data-valmsg-replace=\"true\">";
                var attribute = (ValidationAttribute)property.GetCustomAttribute(typeof(ValidationAttribute));
                output += !attribute?.IsValid(property.GetValue(model)) ?? false
                    ? attribute.ErrorMessage ?? attribute.FormatErrorMessage(property.Name)
                    : string.Empty;
                output += $"</span>";
                return output;
            }

            private static readonly Type[] digitTypes =
               {
                typeof(int),
                typeof(int?),
                typeof(uint),
                typeof(uint?),
                typeof(short),
                typeof(short?),
                typeof(ushort),
                typeof(ushort?),
                typeof(long),
                typeof(long?),
                typeof(ulong),
                typeof(ulong?),
                typeof(nint),
                typeof(nint?),
                typeof(byte),
                typeof(byte?),
                typeof(float),
                typeof(float?),
                typeof(double),
                typeof(double?),
                typeof(decimal),
                typeof(decimal?)
            };

            public static bool IsDigitType(Type T)
            {
                return digitTypes.Any(x => x == T);
            }
        }
    }
}
