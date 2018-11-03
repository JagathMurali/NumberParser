# Number Parser

## Application Specification

Asp.net 4.7.1

Asp.net Mvc 5

Asp.net WebApi

Unity framework

Moq

## How to run the application
    1) Open the solution in Visual Studio
    2) Build the application and check all nuget packages are installed
    3) Run the application by pressing F5
    4) Html page with 2 text boxes will be displayed
    5) After entering the values in the respective field, click submit 
    6) Result will be displayed in the html page.

## Structure of application
    Both front and webservice are part of one project. 

### Front end application
    Html page is loaded using Asp.net MVC controller. All the controls including button is pure html controls. 

    The submit request is an ajax call using jquery. The result of the application is also handled using jquery.

### Webservice application
    Webservice application is an Asp.Net WebApi project with one controller which accept the model which have name and number. 
    
    The response of the post call, is the model itself with translated string as a property.

    Decimal as the type of the number as double have precision issues.

## Area of Improvements
    1) Proper Error logging
    2) Copying constant values to separate file or config file
    3) Automation test cases
    4) Can use Asp.net core to get application develop as well as setup on any OS
