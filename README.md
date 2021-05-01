<h1> Matching Marvel Mania</h1
Superhero pairing game. Test your memory.

<h2>Table of Contents</h2></br>
1.[About](#about)</br>
2.[Installation](#installation)</br>
3.[Usage](#usage)</br>
4.[License](#license)</br>

<h2>About</h2>
This is a simple matching game. Thanks to https://www.mooict.com/c-tutorial-create-a-superhero-memory-game/ we were able to take and expand upon a great matching game. With some update graphics, better functionality and easy of player use has made this a must play game.  
Below is the code snippet to how the accuracy calculates and displays.

        private void DisplayAccuracy()
        {
            float cGCount = Convert.ToInt32(correctGuessCount);
            float gCount = Convert.ToInt32(guessCount);

            float accuracyOfPicks;

            if (cGCount < 1 || gCount < 1)
            {
                accuracyOfPicks = 0;
            }
            else if (gCount % 2 == 0)
            {
                accuracyOfPicks = (cGCount / gCount) * 2;
            }
            else { return; }
            accuracyLabel.Text = accuracyOfPicks.ToString("P", CultureInfo.InvariantCulture);
        }

<h2>Installation</h2>

-This program requires [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/) to run. <br/>
-After installing **Visual Studio 2019**, download link to program and open up executable in the bin file folder.


<h2>Usage</h2>

First, the main screen prompts you to choose:
<br/>-Easy
<br/>-Medium
<br/>-Hard
<br/>
Once in the chosen level you will have 60 seconds to accurately pair the cards. The easy level is a 3x4 grid, 
While in game you will be able to see your accuracy level change as the number of correct and incorrect guesses changes. 

<h2>License</h2>

MIT License

Copyright (c) 2021 princeus93

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
