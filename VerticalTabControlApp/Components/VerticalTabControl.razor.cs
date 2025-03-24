using Microsoft.AspNetCore.Components;

namespace VerticalTabControlApp.Components;

public class VerticalTabControlBase : ComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }

    public VerticalTabPage? ActivePage { get; private set; }
    protected readonly List<VerticalTabPage?> Pages = [];

    internal void AddPage(VerticalTabPage? tabPage)
    {
        Pages.Add(tabPage);
        if (Pages.Count == 1)
            ActivePage = tabPage;
        StateHasChanged();
    }

    protected string GetActiveClass(VerticalTabPage? page) => page == ActivePage ? "active" : "";

    protected void ActivatePage(VerticalTabPage? page)
    {
        ActivePage = page;
        StateHasChanged();
    }
}