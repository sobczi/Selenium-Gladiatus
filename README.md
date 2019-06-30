# Automation for Gladiatus Game
Bot with user-friendly GUI to setup for online game Gladiatus.
## Main
![Alt Text](https://i.imgur.com/Y3i4TQc.jpg)

* Displays whole data about player,
* Sleep (deactivate on mouse-move),
* Take Gold (takes specified amount of gold),
* Sell Items (sells items, moves them on specified backpack),
* Settings (opens settings GUI, descripted below),
* Botting (determines if bot is currently running in normal mode),
  * bold: activated, regular: deactivated,
  * If Take Gold or Sell Items is pressed Botting is deactivated untill user will turn it on back again.

## Settings
![Alt Text](https://i.imgur.com/gxS7bkn.jpg)
* Logging (hopefully here is everything clear),
* Backpacks (determine which backpack bot should use for specific functions),
  * Food (move from packages found/bought food and heal from there).
* General
  * Expedition (choose which enemy bot should attack),
  * Dungeon (determine which dungeons bot should do),
    * Advanced only if currently avaliable,
  * Training (choose skill which bot should training on ending work).
* Limits
  * Heal (below which % bot should heal),
  * Gold pack (over which gold bot should search pack items),
  * Gold take (maximum gold level to take out gold),
  * Food (maximum pages of food to buy from auction house),
  * Boosters (maximum pages of boosters to buy from auction house),
  * Difference (maximum difference between price and value in auction house of items).
* Functions
  * Expedition (bot should go to expeditions),
  * Dungeons (bot should go to dungeons),
  * Event Wars (bot should participate in event wars),
  * Heal (bot should heal player on specified limit),
  * Food (bot should buy new food under limit from auction house),
  * Extract (bot should melt items - currently: orange and red),
  * Sell (bot should sell items - currently: all below orange colours),
  * Auctions (bot should pack rest of unpackable gold in auction house items e.g. rings, amulets),
  * Boosters (bot should buy new boosters under limit from auction house),
  * Sleep (turn sleep mode if user is AFK - didn't found any mouse-move during bot session),
  * Headless (run chrome in headless mode).

## Built with
* C#
* Selenium Framework
* WinForms

## Authors
* Daniel Sobczak - whole work - student of WI ZUT SZCZECIN, POLAND.

## Future
* Add save packages button which will download data from guild market and save it to .txt file to use for gold pack function,
  * Already wrote this, need just to pin it to Settings form.
* Wrote functionality for buying items from auction house (rings, amulets, boosters, food),
* Let user decide if bot should spent rubles on switching to new shops,
* Wrote functionality for trening,
* Auto-Hades (tried in the past but unssuccesfully, kinda tricky).

## Acknowledgments
* Community of Selenium Framework
* Community of Visual Studio
* Community of StackOverFlow :)
* Community of GitHub
