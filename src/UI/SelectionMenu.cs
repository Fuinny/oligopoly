namespace Oligopoly.UI;

internal sealed record SelectionMenuItem(string Text, string[]? Descriptions = null);

internal sealed class SelectionMenu(string[] title, params SelectionMenuItem[] items) : BaseMenu<int>
{
    private protected override void DrawContent()
    {
        foreach (string line in title)
            CenterLine(line);

        for (int currentItem = 0; currentItem < items.Length; currentItem++)
        {
            if (currentItem == SelectedIndex)
                CenterLine($">> {items[currentItem].Text} <<", true);
            else
                CenterLine(items[currentItem].Text);
        }

        if (items[SelectedIndex].Descriptions is null) return;

        CenterLine("");
        CenterLine("Description:");
        CenterLine("");

        foreach (string line in items[SelectedIndex].Descriptions!)
            CenterLine(line);
    }

    private protected override void HandleKeyPress(ConsoleKeyInfo keyPressedInfo)
    {
        switch (keyPressedInfo.Key)
        {
            case ConsoleKey.UpArrow:
                SelectedIndex = (SelectedIndex == 0) ? items.Length - 1 : SelectedIndex - 1;
                break;
            case ConsoleKey.DownArrow:
                SelectedIndex = (SelectedIndex == items.Length - 1) ? 0 : SelectedIndex + 1;
                break;
            case ConsoleKey.Enter:
                Exit = true;
                break;
        }
    }

    private protected override int GetResult() => SelectedIndex;
}
