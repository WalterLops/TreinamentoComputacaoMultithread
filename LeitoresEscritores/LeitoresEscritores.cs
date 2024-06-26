namespace LeitoresEscritores_;

public class LeitoresEscritores
{
    private readonly Semaphore _escritorSemaphore = new(1,1);
    private readonly Mutex _mutexLeitura =  new ();
    private int _contadorLeitores = 0;
    public Stack<string> Stack = new Stack<string>();

    public void Ler(Action acaoLeitura)
    {
        _mutexLeitura.WaitOne();

        _contadorLeitores++;
        if (_contadorLeitores == 1) // O primeiro leitor bloqueia os escritores
            _escritorSemaphore.WaitOne();

        if(Stack.Count != 0)
            acaoLeitura(); 

        _mutexLeitura.ReleaseMutex(); 
        _mutexLeitura.WaitOne();
        
        _contadorLeitores--;
        if (_contadorLeitores == 0) // O último leitor libera os escritores
            _escritorSemaphore.Release();

        _mutexLeitura.ReleaseMutex();
    }

    public void Escrever(Action acaoEscrita)
    {
        _escritorSemaphore.WaitOne(); 
        acaoEscrita(); 
        _escritorSemaphore.Release();
    }
}