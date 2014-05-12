﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Core
{
	/// <summary>
	/// Represents a code generator
	/// </summary>
	public class CodeGenerator
	{

		#region Fields
		private Dictionary<string, MethodInfo> methods;
		private readonly Parser parser;
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a new code generator
		/// </summary>
		/// <param name="parser">The parser</param>
		public CodeGenerator(Parser parser)
		{
			this.parser = parser;
			this.methods = new Dictionary<string, MethodInfo>();
		}
		#endregion

		#region Properties
		/// <summary>
		/// Returns the parser for the generator
		/// </summary>
		public Parser Parser
		{
			get { return this.parser; }
		}

		/// <summary>
		/// Returns the generated methods
		/// </summary>
		public Dictionary<string, MethodInfo> Methods
		{
			get { return this.methods; }
		}
		#endregion

		#region Methods
		
		#endregion

	}

	/// <summary>
	/// Represents a symbol
	/// </summary>
	public abstract class Symbol
	{
		
	}

	/// <summary>
	/// Represents a function argument symbol
	/// </summary>
	public class FunctionArgumentSymbol : Symbol
	{
		/// <summary>
		/// Returns the index of the argument
		/// </summary>
		public int ArgumentIndex { get; private set; }

		/// <summary>
		/// Creates a new function argument symbol
		/// </summary>
		/// <param name="argumentIndex">The index of the symbol</param>
		public FunctionArgumentSymbol(int argumentIndex)
		{
			this.ArgumentIndex = argumentIndex;
		}
	}

	/// <summary>
	/// Represents an local variable symbol
	/// </summary>
	public class LocalVariableSymbol : Symbol
	{
		/// <summary>
		/// Returns the local variable
		/// </summary>
		public LocalBuilder LocalVariable { get; private set; }

		/// <summary>
		/// Creates a new loop variable symbol
		/// </summary>
		/// <param name="argumentIndex">The local variable
		/// </param>
		public LocalVariableSymbol(LocalBuilder localVariable)
		{
			this.LocalVariable = localVariable;
		}
	}

	/// <summary>
	/// Contains generator data for an abstract syntax tree
	/// </summary>
	public class SyntaxTreeGeneratorData
	{

		#region Fields
		/// <summary>
		/// Returns the IL generator
		/// </summary>
		public ILGenerator ILGenerator { get; private set; }

		/// <summary>
		/// Returns the symbol table
		/// </summary>
		public IDictionary<string, Symbol> SymbolTable { get; private set; }
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a new instance of the SyntaxTreeGeneratorData class
		/// </summary>
		/// <param name="ilGenerator">The IL generator</param>
		/// <param name="symbolTable">The symbol table</param>
		public SyntaxTreeGeneratorData(ILGenerator ilGenerator, IDictionary<string, Symbol> symbolTable)
		{
			this.ILGenerator = ilGenerator;
			this.SymbolTable = symbolTable;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Returns an empty instance
		/// </summary>
		public static SyntaxTreeGeneratorData Empty
		{
			get { return new SyntaxTreeGeneratorData(null, new Dictionary<string, Symbol>()); }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Adds the given symbol to the current symbol table
		/// </summary>
		/// <param name="symbolName">The name of the symbol</param>
		/// <param name="symbol">The symbol</param>
		/// <returns>A new generator with the added symbol</returns>
		public SyntaxTreeGeneratorData WithSymbol(string symbolName, Symbol symbol)
		{
			Dictionary<string, Symbol> symbolTable = new Dictionary<string, Symbol>(this.SymbolTable);
			symbolTable.Add(symbolName, symbol);
			return new SyntaxTreeGeneratorData(this.ILGenerator, symbolTable);
		}
		#endregion

	}
}
