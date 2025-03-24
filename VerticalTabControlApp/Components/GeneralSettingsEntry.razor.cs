using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace VerticalTabControlApp.Components;

public partial class GeneralSettingsEntry : ComponentBase
{
    [Parameter] public string Title { get; set; }
    
    protected EditContext? EditContext;

    protected GeneralSettingsInputModel Model = new();
    
    public List<AccordionItem> AccordionItems { get; set; } = new List<AccordionItem>();

        private const string General = "General";
        private const string StartDetectionSettings = "Start Detection Settings";
        private const string ShutdownSettings = "Shutdown Settings";
    
    protected override void OnInitialized()
    {
        EditContext = new EditContext(Model);

        AccordionItems.Add(new AccordionItem {Title = General, CssCollapsed = "", CssShow = "show", IsAriaExpanded = true});
        AccordionItems.Add(new AccordionItem {Title = StartDetectionSettings, CssCollapsed = "collapsed"});
        AccordionItems.Add(new AccordionItem {Title = ShutdownSettings, CssCollapsed = "collapsed"});
    }
    private void ToggleAccordion(AccordionItem item)
    {
        item.CssCollapsed = item.CssCollapsed == "collapsed" ?  "" :  "collapsed";
        item.CssShow = item.CssShow == "show" ?  "" : "show";
        item.IsAriaExpanded = !item.IsAriaExpanded;
    }
}

public class GeneralSettingsInputModel
{
    public string? DefaultDataPath { get; set; }
    public bool IsBackupAscentRtso { get; set; }
    public bool IsBackupZipFile { get; set; }
    public string? Directory { get; set; }
    public bool IsRawDataValidationBeforeAscent { get; set; }
    public bool IsAdjustSystemTimeByGps { get; set; }
    public bool IsAdjustSystemTimeByNtp { get; set; }
    public string? NtpServer { get; set; }
    public string? MenuType { get; set; }
    public int NumberOfSondes { get; set; }
    public bool IsRepeatAscentIfNecessary { get; set; }
    public bool IsAllowAddingDetectedStartTime { get; set; }
    public bool IsOpenGroundDataWindowAfterStart { get; set; }
    public bool IsShutdownAfterSoundingWasStopped { get; set; }
    public int DelayInMinutes { get; set; }
}

public class AccordionItem
{
    public string? Title { get; set; }
    public string CssCollapsed { get; set; } = "";
    public string CssShow { get; set; } = "";
    public bool IsAriaExpanded { get; set; }
}