using CatchUpPlatform.API.Shared.Domain.Infrastructure.Interfaces.Asp.Configuration.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace CatchUpPlatform.API.Shared.Domain.Infrastructure.Interfaces.Asp.Configuration;

public class KebabCaseRouteNamingConventions: IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors)
        {
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        }
        
        foreach (var selector in controller.Actions.SelectMany(action => action.Selectors))
        {
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        }
    }


    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string newControllerName)
    {
     return selector.AttributeRouteModel != null
            ? new AttributeRouteModel
            {
                Template = selector.AttributeRouteModel.Template?.Replace("[controller]", newControllerName.ToKebabCase())
            }
            : null;   
    }
}