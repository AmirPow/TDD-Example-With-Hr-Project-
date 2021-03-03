using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API
{

    //public sealed class RequireValueTypePropertiesSchemaFilter : ISchemaFilter
    //{
    //    private readonly CamelCasePropertyNamesContractResolver camelCaseContractResolver;


    //    /// <summary>
    //    /// Initializes a new <see cref="RequireValueTypePropertiesSchemaFilter"/>.
    //    /// </summary>
    //    /// <param name="camelCasePropertyNames">If <c>true</c>, property names are expected to be camel-cased in the JSON schema.</param>
    //    /// <remarks>
    //    /// I couldn't figure out a way to determine if the swagger generator is using <see cref="CamelCaseNamingStrategy"/> or not;
    //    /// so <paramref name="camelCasePropertyNames"/> needs to be passed in since it can't be determined.
    //    /// </remarks>
    //    public RequireValueTypePropertiesSchemaFilter(bool camelCasePropertyNames)
    //    {
    //        camelCaseContractResolver = camelCasePropertyNames ? new CamelCasePropertyNamesContractResolver() : null;
    //    }


    //    /// <summary>
    //    /// Adds non-nullable value type properties in a <see cref="Type"/> to the set of required properties for that type.
    //    /// </summary>
    //    /// <param name="model"></param>
    //    /// <param name="context"></param>
    //    public void Apply(Schema model, SchemaFilterContext context)
    //    {
    //        foreach (var property in context.SystemType.GetProperties())
    //        {
    //            var schemaPropertyName = PropertyName(property);

    //            if (property.PropertyType == typeof(TimeSpan) || property.PropertyType == typeof(TimeSpan?))
    //            {
    //                if (model.Properties?.ContainsKey(schemaPropertyName) == true)
    //                {
    //                    model.Properties.Single(a => a.Key == schemaPropertyName).Value.Format = "time-span";
    //                }
    //            }

    //            // This check ensures that properties that are not in the schema are not added as required.
    //            // This includes properties marked with [IgnoreDataMember] or [JsonIgnore] (should not be present in schema or required).
    //            if (model.Properties?.ContainsKey(schemaPropertyName) == true)
    //            {
    //                // Value type properties are required,
    //                // except: Properties of type Nullable<T> are not required.
    //                var propertyType = property.PropertyType;
    //                if (propertyType.IsValueType &&
    //                    !(propertyType.IsConstructedGenericType &&
    //                      propertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
    //                {
    //                    //Properties marked with[Required] are already required(don't require it again).
    //                    if (!property.CustomAttributes.Any(attr =>
    //                    {
    //                        var t = attr.AttributeType;
    //                        return t == typeof(RequiredAttribute);
    //                    }))
    //                    {
    //                        // Make the value type property required
    //                        if (model.Required == null)
    //                        {
    //                            model.Required = new List<string>();
    //                        }

    //                        model.Required.Add(schemaPropertyName);
    //                    }
    //                }
    //            }
    //        }
    //    }


    //    /// <summary>
    //    /// Returns the JSON property name for <paramref name="property"/>.
    //    /// </summary>
    //    /// <param name="property"></param>
    //    /// <returns></returns>
    //    private string PropertyName(PropertyInfo property)
    //    {
    //        return camelCaseContractResolver?.GetResolvedPropertyName(property.Name) ?? property.Name;
    //    }
    //}
    public sealed class RequireValueTypePropertiesSchemaFilter : ISchemaFilter
        {
            private readonly CamelCasePropertyNamesContractResolver camelCaseContractResolver;


            /// <summary>
            /// Initializes a new <see cref="RequireValueTypePropertiesSchemaFilter"/>.
            /// </summary>
            /// <param name="camelCasePropertyNames">If <c>true</c>, property names are expected to be camel-cased in the JSON schema.</param>
            /// <remarks>
            /// I couldn't figure out a way to determine if the swagger generator is using <see cref="CamelCaseNamingStrategy"/> or not;
            /// so <paramref name="camelCasePropertyNames"/> needs to be passed in since it can't be determined.
            /// </remarks>
            public RequireValueTypePropertiesSchemaFilter(bool camelCasePropertyNames)
            {
                camelCaseContractResolver = camelCasePropertyNames ? new CamelCasePropertyNamesContractResolver() : null;
            }


            /// <summary>
            /// Adds non-nullable value type properties in a <see cref="Type"/> to the set of required properties for that type.
            /// </summary>
            /// <param name="model"></param>
            /// <param name="context"></param>
            public void Apply(OpenApiSchema model, SchemaFilterContext context)
            {

                var ttt = context.SchemaRepository.Schemas.Keys.Where(r => r.EndsWith("TimeSpan"));
                foreach (var item in ttt)
                    context.SchemaRepository.Schemas.Remove(item);

                foreach (var property in context.Type.GetProperties())
                {
                    var schemaPropertyName = PropertyName(property);

                    if (property.PropertyType == typeof(DateTime?))
                    {
                        var value = model.Properties.Single(a => a.Key == schemaPropertyName).Value;
                    }

                    if (property.PropertyType == typeof(TimeSpan?))
                    {
                        if (model.Properties?.ContainsKey(schemaPropertyName) == true)
                        {
                            model.Properties.Single(a => a.Key == schemaPropertyName).Value.Format = "time-span";
                            model.Properties.Single(a => a.Key == schemaPropertyName).Value.Reference = null;
                            model.Properties.Single(a => a.Key == schemaPropertyName).Value.Nullable = true;
                            model.Properties.Single(a => a.Key == schemaPropertyName).Value.Type = "string";
                        }
                    }
                    if (property.PropertyType == typeof(TimeSpan))
                    {
                        if (model.Properties?.ContainsKey(schemaPropertyName) == true)
                        {
                            model.Properties.Single(a => a.Key == schemaPropertyName).Value.Format = "time-span";
                            model.Properties.Single(a => a.Key == schemaPropertyName).Value.Reference = null;
                            model.Properties.Single(a => a.Key == schemaPropertyName).Value.Nullable = false;
                            model.Properties.Single(a => a.Key == schemaPropertyName).Value.Type = "string";
                        }
                    }


                    if (model.Properties?.ContainsKey(schemaPropertyName) == true)
                    {

                        var propertyType = property.PropertyType;
                        if (propertyType.IsValueType &&
                            !(propertyType.IsConstructedGenericType &&
                              propertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            if (!property.CustomAttributes.Any(attr =>
                            {
                                var t = attr.AttributeType;
                                return t == typeof(RequiredAttribute);
                            }))
                            {
                                if (model.Required == null)
                                {
                                    model.Required = new HashSet<string>();
                                }

                                model.Required.Add(schemaPropertyName);
                            }
                        }
                    }
                }
            }



            /// <summary>
            /// Returns the JSON property name for <paramref name="property"/>.
            /// </summary>
            /// <param name="property"></param>
            /// <returns></returns>
            private string PropertyName(PropertyInfo property)
            {
                return camelCaseContractResolver?.GetResolvedPropertyName(property.Name) ?? property.Name;
            }
        }
    }

