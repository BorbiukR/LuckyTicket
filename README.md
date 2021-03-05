# LuckyTicket
![searching...](https://media.giphy.com/media/l2JdTUDj26z4hDqLu/giphy.gif)

Сonsole application that determines if the ticket number entered by the user is lucky $$$. 
The ticket number is a number that can be 4 to 8 digits long.
If the user entered a number that contains an odd number of digits, then 0 must be added at the beginning of the ticket number.
A ticket is considered lucky if the sum of its first half is equal to the sum of the second half.

## Example
enetered number - 12056
<br/>this is an odd number, so we add 0 at the beginning of the ticket number - as a result we get - 012056
<br/>
<br/>divide into two halfs: 
<br/>1st half - 012
<br/>2nd half - 056
<br/>
<br/>count the sum of the digits of each half: 
<br/>1st half - 0 + 1 + 2 = 3  
2nd half - 0 + 5 + 6 = 11 
<br/>
<br/>then check the equality of the 1st and 2nd half : 3 = 11 ? 
<br/>3 is not equal to 11, so the ticket is not lucky

## Application Start
When you double click run.bat file, the program build and starts. 
<br/>Then you have the option to play by pressing the key [P] or to exit the program by pressing [E]
