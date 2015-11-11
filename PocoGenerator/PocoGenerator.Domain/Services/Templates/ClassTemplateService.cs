﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Interfaces.Templates;
using DotLiquid;
using PocoGenerator.Domain.Models;

namespace PocoGenerator.Domain.Services.Templates
{
    public class ClassTemplateService : ITemplate<SysObjects>
    {
        private readonly ITemplate<PropertiesTemplateSevice> _propertiesTemplateService;

        public ClassTemplateService(ITemplate<PropertiesTemplateSevice> propertiesTemplateService)
        {
            _propertiesTemplateService = propertiesTemplateService;
        }

        public Template GetTemplate()
        {
            StringBuilder sbTemplate = new StringBuilder();
            sbTemplate.Append("public class {{sysobjects.Name}}");
            sbTemplate.AppendLine();
            sbTemplate.Append("{");
            sbTemplate.AppendLine();
            sbTemplate.Append("\t");
            sbTemplate.Append(_propertiesTemplateService.GetTemplate());
            sbTemplate.AppendLine();
            sbTemplate.Append("}");

            return Template.Parse(sbTemplate.ToString());
        }
    }
}
