using Microsoft.AspNetCore.Components;

namespace VerticalTabControlApp.Components;

public class VerticalTabControlBase : ComponentBase
{
[Parameter] public RenderFragment? ChildContent { get; set; }

public TabPage? ActivePage { get; private set; }
protected readonly List<TabPage?> Pages = [];

internal void AddPage(TabPage? tabPage)
{
    Pages.Add(tabPage);
    if (Pages.Count == 1)
        ActivePage = tabPage;
    StateHasChanged();
}

protected string GetActiveClass(TabPage? page) => page == ActivePage ? "active" : "";

protected void ActivatePage(TabPage? page)
{
    ActivePage = page;
    StateHasChanged();
}

}