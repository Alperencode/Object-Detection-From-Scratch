# VisioTT

***Will be updated***

## Images


<h2> Face Similarity (With Emgu Library)</h2>

Face Similarity program using EmguCV. EmguCV is a library that allows us to use OpenCV in C#. So I used OpenCV's face detection functions to implement simple similarity algorithm that I wrote. The algorithm extracts both faces and compares pixel's color similarity and calculates a similarity score. In addition program works in real-time and uses video capture device as input device.

<h3 align=center>

<img src="images/FaceSimilarity/0-FaceDetectionSimilarity.png">

Face Detection Similarity Check

<br>

<h2> Coin Detection Project (Using GetPixel) (Without Library)</h2>

This is the first long-term project that is assigned to me. In this project **I was challenged to not use any library or module** for anything. Just by using C# System functions, I needed to detect both coins and determine which one has black dot on it.

So I worked on *coin detection* algorithm first then developed a *dot detection algorithm*.

Firstly, I needed to detect coins. I did this using pixel similarity formula from the face similarity program. If pixel is similar with gray, pass that pixel, else set pixel as red (Image 1). Note: In future I implemented a function that scans image specific percentage and determines background color.

After that point, that means I can tell the difference between coin and background. So I worked on algorithm that based on this.

First, I scanned image pixels vertically to find coin's width, then I scanned horizontally to detect height (Image 2, 3, 4, 5, 6).

Then I draw rectangles around coins using that coordinates (Image 7, 8). That means I detected the coins and now I can extract them as two images and run a dot detection algorithm (Image 9).

So I implemented a simple dot detection algorithm that counts black pixels in image since I can use coins as 2 different images (Image 10).

Afterwards I draw ellipse on coin with dot (Image 11) and I added a settings section to not use any static variables in my code (Image 12, 13). 

<h3 align=center>

<img src="images/CoinDotDetection/1-DetectingCoins.png">

1) Detecting Coins

<br>

<img src="images/CoinDotDetection/2-FindingFirstCoinXStart.png">

2) Finding First Coin X Start

<br>

<img src="images/CoinDotDetection/3-FindingFirstCoinXEnd.png">

3) Finding First Coin X End

<br>

<img src="images/CoinDotDetection/4-FindingBothCoinsXAxis.png">

4) Finding Both Coins X Axis

<br>

<img src="images/CoinDotDetection/5-DrawingRedLinesForCoinsWidth.png">

5) Drawing Red Lines for Width

<br>

<img src="images/CoinDotDetection/6-DrawingRedLinesForBothCoins.png">

6) Drawing Red Lines For Height

<br>

<img src="images/CoinDotDetection/7.1-DrawingRectangleForBothCoins.png">

7) Drawing Rectangle For Both Coins - 1

<br>

<img src="images/CoinDotDetection/7.2-DrawingRectangleForBothCoins.png">

8) Drawing Rectangle For Both Coins - 2

<br>

<img src="images/CoinDotDetection/8-CroppingBothCoins.png">

9) Cropping Both Coins

<br>

<img src="images/CoinDotDetection/9-DetectingCoinWithDot.png">

10) Detecting Coin With Dot

<br>

<img src="images/CoinDotDetection/10-DrawingEllipse.png">

11) Drawing Ellipse to Coin With Dot

<br>

<img src="images/CoinDotDetection/11-AddingSettingsSection.png">

12) Adding Settings Section

<br>

<img src="images/CoinDotDetection/12-AdvancedSettingsSection.png">

13) Improving Settings section and UI

<br>

<h2> Coin Detection Project Improved (Using byte arrays) (Without Library)</h2>

My first project's method was easy to implement because I was using GetPixel() function. But in this method only way to traverse image pixels was using 2 for loop because pixels was stored in 2D matrix. That limitation significantyl slows the performance of the program.

So I developed a new algorithm that is based on byte arrays. In byte array, whole image is one array and that array contains image bytes. Each 3 sequence of bytes represents 1 pixel's RGB.

I developed an algorithm that slightly different from the first one because in byte array, I have one dimensional array. In the beginning I converted image to Black and White to seperate background and coins (Image 1). Then I cleared up the black pixels in coin (Image 2). I did that using simple logic that searchs for black sequence of pixels horizontally if there is no sequence, it converts that black pixel to white. 

That was the most time consuming part for the program but it was necessary for finding width and height in next iterations because if we don't clean the black pixels in coin, we need to search for black sequence to determine if the coin ended or not. But if we clean the pixels then whenever we encounter black pixel, we can say that its the end of the coin (Image 3).

Then I started to develop an algorithm to find width and height (Image 4). It was not working well in the beginning because it has some bugs and logical mistakes (Image 5). But I kept improving the algorithm and finally implemented a solid algorithm that can detect coins and finds width, height and (x,y) coordinates for each coin (Image 6).

After detecting the coins its easy to determine which one has dot in it. I've cropped the coins from image using width and height coordinates. Then I scanned both ...

<h3 align=center>


<img src="images/CoinDotDetectionImproved/1-CoinsBlackAndWhite.png">

1) Converting Image bytes to black and white 

<br>

<img src="images/CoinDotDetectionImproved/2.1-CoinsClearedB&W.png">

Cleaning up black pixels in coin

<br>

<img src="images/CoinDotDetectionImproved/2.2-CoinsClearedB&W.png">

Improving clearing 

<br>

<img src="images/CoinDotDetectionImproved/3.1-DrawingLinesNotFixed-1.png">

First detection try using byte arrays

<br>

<img src="images/CoinDotDetectionImproved/3.2-DrawingLinesNotFixed-2.png">

Drawing rectangles

<br>

<img src="images/CoinDotDetectionImproved/3.3-DrawingLinesNearlyFixed.png">

Improving detection algorithm

<br>

<img src="images/CoinDotDetectionImproved/4-Finished.png">

Finishing detection and coin with dot algorithm

<br>

<img src="images/CoinDotDetectionImproved/5.2-FinishedWithSettings2.png">

Adding settings section to make project dynamic

</h3>