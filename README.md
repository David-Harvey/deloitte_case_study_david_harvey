# Case Study – David Harvey

## Brief explanation of design:

The application design is made up of several key components which drives the organisation of activities. 
By splitting the application into different components, each component has a single purpose making testing easier to isolate functionality.

Interfaces were used for each key component, injecting behaviour, so that the application could be changed without breaking other key components. An example of this is the IProvider, the IProvider defines a method which must return the data to be consumed, and this could be later extended to be a database connection provider or a connected services provider.

Benefits of using interfaces and injecting dependencies meant I could easily isolate and mock out components using NSubstitute.
Most of the design principles used in my application were based on SOLID.

### Key components: 

### IProvider.cs

Used for providing data, this could be anything as long as it provides data in a format of strings. An example would be a file provider, or a database provider.

### IOrganiser.cs

Used for organising data and responsible for parsing input based on settings provided.

### ISchedule.cs

Defines how the schedule should be laid out.

### IScheduler.cs

A wrapper for all the main components and settings, and schedules the activities.

### ISettings.cs

Used for providing the application with settings throughout the code.

### IBaseActivity.cs

A definition of the data to be provided to the organiser for organising.

### Program.cs

Provides the output of the application that is provided by the IScheduler.
 
## Assumptions:

- There are only two teams to have all the activities split against.
- The application only needs to support reading in one file at a time.
- The order of activities does not matter.
- The time of the activities does not need to be balanced across teams.
- Unit tests and acceptance tests are feasible, and can be developed using BDD/TDD with Machine specifications. 


## Detailed instructions:

### Repository (GitHub): https://github.com/David-Harvey/deloitte_case_study_david_harvey

### Requirements:
This app will require you to run it using window with .NET 4.6.1 installed or greater, and or Visual Studio 2017. 

There are two ways to run this application:
- Via command line 
- Visual Studio 2017 

### Command line:
I have purposely committed the 
[excutable in the bin release folder](https://github.com/David-Harvey/deloitte_case_study_david_harvey/tree/master/DeloitteCaseStudy_DavidHarvey/bin/Release) so you don’t need to build it using Visual Studio 2017.

- Clone the GitHub repository and navigate to the directory using Command Line.
- Execute the following command: DeloitteCaseStudy_DavidHarvey.exe .\sampledata.txt 
- Alternatively you can provide an alternative source of sample data. This can be in the form of a relative, or full path.

### Visual Studio 2017:
- Open solution from root project directory
- Build 
- Run or debug using either release/debug configurations.
