# UI test automation framework built with specflow and selenium
This is a living project with functionality that will be extended regularly to advance knowledge of latest web testing tools and best practices. This is a collaborative project between myself and @LulzimAhmeti. 

## MVP
- Implement Page Object Model design pattern - DONE
- Integrate Specflow into project - DONE
- Have test setup and test teardown that are run before and after each scenario - DONE
- Add screenshot taking capability to screenshot NoSuchElementException events for enhanced debugging - DONE
- Implement Sing-in scenario - DONE
- Implement Add topics scenario - DONE

## Possible Extensions
- Extend the project to allow for cross browser testing - TODO
- Host the project on a cloud hosting platform to enable automated nightly test runs in CI/CD pipeline - TODO
- Extend the project to integrate Selenium Grid to enable parallel running of tests on multiple browsers in the cloud - TODO

### Sign-in scenario giphy
![](sing-in-scenario.gif)

### Add topics scenario giphy
![](add-topics-scenario.gif)

## Installing and running the project in Visual Studio 2019
1. Clone project or download as Zip
2. Open Visual Studio, build solution and navigate to Test and open Test Explorer
3. Select a specflow scenario, right click on it and hit run. To run all specflow scenarios at once, right click on regression folder and hit run

If you do not have Specflow for Visual Studio extension installed, you will need to install it after step 1. To install Specflow for Visual Studio extension, open Visual Studio, navigate to Manage Extensions and install it. After installing it succesfully, move onto step 2.

## To run it from Command Prompt or Git Bash
1. Open Git Bash in the project directory or open Command Prompt and navigate to project directory
2. To run all specflow test scenarios, enter the following command and hit enter
> dotnet test

## Some of the resources used to complete this project
- https://www.selenium.dev/selenium/docs/api/dotnet/index.html
- https://www.automatetheplanet.com/selenium-webdriver-locators-cheat-sheet/
- https://specflow.org/documentation/
- https://ultimateqa.com/common-selenium-webdriver-errors-fix/
- https://ui.vision/rpa/docs/selenium-ide
- https://devhints.io/xpath
- https://specflow.org/documentation/Troubleshooting-Visual-Studio-Integration/
- https://medium.com/@josephcardillo/how-to-add-gifs-to-your-github-readme-89c74da2ce47
