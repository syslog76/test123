namespace lang.Service;
public class KeysService<T>
{
    public Guid GenKey(T text)
    {
        var result = Guid.NewGuid();

        return result;
    }
}
