﻿using SmartHoldemNet.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SmartHoldemNet.Messages.BaseMessages
{
    public class SmartHoldemBaseRequest
    {
        protected readonly List<string> QueryParams = new List<string>();

        [SmartHoldemQueryParam(Name = "limit")]
        public int? Limit { get; set; }

        [SmartHoldemQueryParam(Name = "offset")]
        public int? Offset { get; set; }

        [SmartHoldemQueryParam(Name = "orderBy")]
        public string OrderBy { get; set; }

        public virtual string ToQuery()
        {
            var propCollection = GetType().GetRuntimeProperties();

            foreach (PropertyInfo property in propCollection)
            {
                foreach (var attribute in property.GetCustomAttributes(true))
                {
                    if (attribute is SmartHoldemQueryParamAttribute attr)
                    {
                        var val = property.GetValue(this);
                        if (val != null)
                            QueryParams.Add($"{attr.Name}={val}");
                    }
                }
            }

            return "?" + string.Join("&", QueryParams.ToArray());
        }
    }
}
