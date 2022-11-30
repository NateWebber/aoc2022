# Advent of Code 2022
This is a repository of my solutions for [Advent of Code 2022](adventofcode.com). This is the second year that I have participated, and the first time I'm participating from Day 1. My goal for this year is to eventually finish, something I struggled with last year due to the typical end-of-semester chaos that comes this time of year when you're a college student.

This year I've decided to write my solutions in C#. I'm actually fairly inexperienced with this language, which is why I'm hoping that these puzzles will give me an opportunity to get a solid foundation in it. Java is my current preferred language, but from the work I've already done with C# I have a suspicion it will overtake it soon.

I've designed a template and master app structure to hopefully make my life easier with these problems. By my current design, the entry point of the project is **App.cs**, which is essentially just a wrapper for a switch statement to access the "day" classes, which go in the *days* directory and follow the naming convention of **DXX.cs**. Input files go in the *inputs* directory, and follow the naming convention of simply **XX**. I run the program from the command line with a single required argument, an integer for the day to run (e.g. 1). A second, optional argument is an overrride for the default input file path. It assumes that the file is in the *inputs* directory (i.e. one should simply provide "foo" instead of "inputs/foo").

I'll probably come back and upate this README as the month goes on, making notes about things that I learned or had to do to get through the challenges. I'll try and eventually write a wrap-up blog post of some sort, and if I'll post it on [natewebber.dev]() and link it here.