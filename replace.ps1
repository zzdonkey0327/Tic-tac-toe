$content = Get-Content Poker\Form1.cs -Raw

$oldText1 = "        private Image GetFaceImageForCard(int card)
        {
            if (IsJoker(card))
            {
                return SafeGetJokerImage();
            }

            return Properties.Resources.back;
        }"

$newText1 = "        private Image GetFaceImageForCard(int card)
        {
            if (IsJoker(card))
            {
                return SafeGetJokerImage();
            }

            try
            {
                object obj = Properties.Resources.ResourceManager.GetObject("pic" + card);
                if (obj != null)
                {
                    return (Image)obj;
                }
            }
            catch
            {
            }
            return Properties.Resources.back;
        }"

$content = $content -replace [regex]::Escape($oldText1), $newText1

$oldText2 = "        private Image GetBoardCardImage(Cell cell)
        {
            if (cell.Owner == Side.None)
            {
                return Properties.Resources.back;
            }

            if (IsJoker(cell.Value))
            {
                return SafeGetJokerImage();
            }

            return Properties.Resources.back;
        }"

$newText2 = "        private Image GetBoardCardImage(Cell cell)
        {
            if (cell.Owner == Side.None)
            {
                return Properties.Resources.back;
            }

            if (IsJoker(cell.Value))
            {
                return SafeGetJokerImage();
            }

            try
            {
                object obj = Properties.Resources.ResourceManager.GetObject("pic" + cell.Value);
                if (obj != null)
                {
                    return (Image)obj;
                }
            }
            catch
            {
            }
            return Properties.Resources.back;
        }"

$content = $content -replace [regex]::Escape($oldText2), $newText2

Set-Content -Path Poker\Form1.cs -Value $content
