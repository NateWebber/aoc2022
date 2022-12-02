interface Day
{
    /*
    * Only needed for the sake of reflection, so the compiler doesn't get mad when I invoke Run() on an arbitrarily determined class
    */
    void Run(string inPath);

}