using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace VerticalTabControlApp.Components.Refactored;

public partial class RefactoredGeneralSettingsEntry : ComponentBase
{
    [Parameter] public string AccordionTitle { get; set; } = "";

    private readonly GeneralSettingsInputModel _model = new();
    private EditContext? _editContext;
    
    public List<AccordionItem> AccordionItems { get; set; } = new();

    private const string General = "General";
    private const string StartDetectionSettings = "Start Detection Settings";
    private const string ShutdownSettings = "Shutdown Settings";
    
    protected override void OnInitialized()
    {
        _editContext = new EditContext(_model);
        _editContext.OnFieldChanged += EditContextOnOnFieldChanged;

        AccordionItems.Add(new AccordionItem {Title = General, CssCollapsed = "", CssShow = "show", IsAriaExpanded = true});
        AccordionItems.Add(new AccordionItem {Title = StartDetectionSettings, CssCollapsed = "collapsed"});
        AccordionItems.Add(new AccordionItem {Title = ShutdownSettings, CssCollapsed = "collapsed"});
    }

    private void EditContextOnOnFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        
    }


    private const string IdDefaultDataPath = "idDefaultDataPath"; 
    
    private void ToggleAccordion(AccordionItem item)
    {
        item.CssCollapsed = item.CssCollapsed == "collapsed" ?  "" :  "collapsed";
        item.CssShow = item.CssShow == "show" ?  "" : "show";
        item.IsAriaExpanded = !item.IsAriaExpanded;
    }
    
    
        // private void OnFocus(string obj)
        // {
        //
        // }


        private  void OnFocus(string id)
        {
            if (id == IdDefaultDataPath)
            {
                Console.WriteLine("IdDefaultDataPath focused");
                InfoTitle = "Default Data Path:";
                InfoDescription = "Path were all the data is stored";
            }
        }

        public string InfoDescription { get; set; } = "";

        public string InfoTitle { get; set; } = "";
}

