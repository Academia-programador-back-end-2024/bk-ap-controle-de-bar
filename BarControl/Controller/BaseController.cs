using BarControl.Data;
using BarControl.Model;

namespace BarControl.Controller;

public class BaseController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly BarControlContext _context;

    public BaseController(BarControlContext context)
    {
        _context = context;
    }

    public string IsRelatedToSlip(BaseModel model)
    {
        var modelType = model.GetType();
        string errorMessage  = string.Empty;
        foreach(Slip slip in _context.Slip)
        {
            if (modelType == typeof(Client))
            {
                if (slip.Client == model)
                {
                    errorMessage = $"{model} is related to a slip and cannot be deleted!";
                    Slip relatedSlip = slip;
                }
            }
            if (modelType == typeof(Waiter))
            {
                if (slip.Waiter == model)
                {
                    errorMessage = $"{model} is related to a slip and cannot be deleted!";
                    Slip relatedSlip = slip;
                }
            }
            if (modelType == typeof(Table))
            {
                if (slip.Table == model)
                {
                    errorMessage = $"{model} is related to a slip and cannot be deleted!";
                    Slip relatedSlip = slip;
                }
            }
        }

        return errorMessage;
    }
}
