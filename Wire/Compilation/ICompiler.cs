using System;
using System.Reflection;

namespace Wire.Compilation
{
    public interface ICompiler<out TDel>
    {
        int NewObject(Type type);
        int Parameter<T>(string name);
        int Variable<T>(string name);
        int GetVariable<T>(string name);
        int Constant(object value);
        int CastOrUnbox(int value, Type type);
        void EmitCall(MethodInfo method, int target, params int[] arguments);
        void EmitStaticCall(MethodInfo method, params int[] arguments);
        int Call(MethodInfo method, int target, params int[] arguments);
        int StaticCall(MethodInfo method, params int[] arguments);
        int ReadField(FieldInfo field, int target);
        int WriteField(FieldInfo field, int target, int value);
        TDel Compile();
        int Convert<T>(int value);
        int WriteVar(int variable, int value);
        void Emit(int value);
        int Convert(int value, Type type);
    }
}