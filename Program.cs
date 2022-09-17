// See https://aka.ms/new-console-template for more information
using Transport;


Station A = new Station("A");
Station B = new Station("B");
Station C = new Station("C");
Station D = new Station("D");
Station E = new Station("E");
Station F = new Station("F");

Link L1 = new Link("A", "B", 2, "Victoria (Southbound)");
Link L2 = new Link("A", "C", 4, "Jubilee (Eastbound)");
Link L3 = new Link("B", "C", 1, "Victoria (Southbound)");
Link L4 = new Link("B", "D", 7, "Jubilee (Eastbound)");
Link L5 = new Link("C", "E", 3, "Jubilee (Eastbound)");
Link L6 = new Link("E", "D", 2, "Jubilee (Eastbound)");
Link L7 = new Link("D", "F", 1, "Jubilee (Eastbound)");
Link L8 = new Link("E", "F", 5, "Victoria (Eastbound)");

StationList stationList = new StationList();
stationList.addStation(A);
stationList.addStation(B);
stationList.addStation(C);
stationList.addStation(D);
stationList.addStation(E);
stationList.addStation(F);


stationList.addLink(A, L1);
stationList.addLink(A, L2);
stationList.addLink(B, L3);
stationList.addLink(B, L4);
stationList.addLink(C, L5);
stationList.addLink(D, L7);
stationList.addLink(E, L6);
stationList.addLink(E, L8);

//L4.closeTrack();
//L7.closeTrack();
L3.addDelay(1);
L4.addDelay(4);
L2.addDelay(3);

L3.removeDelay();
L4.removeDelay();
L2.removeDelay();


ShortPath sp1 = new ShortPath();
sp1.shortPath(stationList, A, F);

//sp1.generateReport(abc);

UserInput.selection();

/*
Console.WriteLine("Hello, World!");
Station A = new Station("A");
Station B = new Station("B");
Station C = new Station("C");
Station D = new Station("D");

Link L1 = new Link("A", "B", 5);
Link L2 = new Link("B", "C", 10);
Link L3 = new Link("C", "D", 14);
Link L4 = new Link("D", "A", 33);
Link L5 = new Link("B", "D", 22);

Link L6 = new Link("B", "A", 17);

//L2.closeTrack();
//Add station to station list

StationList stationList = new StationList();
stationList.addStation(A);
stationList.addStation(B);
stationList.addStation(C);
stationList.addStation(D);

//Add link
stationList.addLink(A, L1);
stationList.addLink(B, L2);
stationList.addLink(C, L3);
stationList.addLink(D, L4);
stationList.addLink(B, L5);
stationList.addLink(B, L6);

L5.closeTrack();

//Display Station
Console.WriteLine("Display Station");
stationList.displayStation();

//Display Links
Console.WriteLine("Display Links");
stationList.displayLink();

//Display Closed Links
Console.WriteLine("Display Closed Links");
StationList.displayClosedLink();

//Display short path
ShortPath sp1 = new ShortPath();
sp1.shortPath(stationList, B, D);
*/