﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Data
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using Narvalo.Internal;

    [ContractClass(typeof(StoredProcedureContract<>))]
    public abstract class StoredProcedure<TResult>
    {
        private readonly string _connectionString;
        private readonly string _name;

        private CommandBehavior _commandBehavior
            = CommandBehavior.CloseConnection | CommandBehavior.SingleResult;

        protected StoredProcedure(string connectionString, string name)
        {
            Require.NotNullOrEmpty(connectionString, "connectionString");
            Require.NotNullOrEmpty(name, "name");

            _connectionString = connectionString;
            _name = name;
        }

        protected CommandBehavior CommandBehavior
        {
            get { return _commandBehavior; }
            set { _commandBehavior = value; }
        }

        protected string ConnectionString
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);
                return _connectionString;
            }
        }

        protected string Name
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);
                return _name;
            }
        }

        public TResult Execute()
        {
            TResult result;

            using (var connection = CreateConnection_())
            {
                using (var command = CreateCommand_(connection))
                {
                    PrepareParameters(command.Parameters.AssumeNotNull());

                    connection.Open();

                    using (var reader = ExecuteCommand_(command))
                    {
                        result = Execute(reader);
                    }
                }
            }

            return result;
        }

        protected abstract TResult Execute(SqlDataReader reader);

        protected abstract void PrepareParameters(SqlParameterCollection parameters);

        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities",
            Justification = "The Code Analysis error is real, but we expect the consumer of this class to use a named SQL procedure.")]
        private SqlCommand CreateCommand_(SqlConnection connection)
        {
            Contract.Requires(connection != null);
            Contract.Ensures(Contract.Result<SqlCommand>() != null);

            SqlCommand tmpCmd = null;
            SqlCommand cmd = null;

            try
            {
                tmpCmd = new SqlCommand(Name, connection);
                tmpCmd.CommandType = CommandType.StoredProcedure;

                cmd = tmpCmd;
                tmpCmd = null;
            }
            finally
            {
                if (tmpCmd != null)
                {
                    tmpCmd.Dispose();
                }
            }

            return cmd;
        }

        private SqlConnection CreateConnection_()
        {
            Contract.Ensures(Contract.Result<SqlConnection>() != null);

            return new SqlConnection(ConnectionString);
        }

        private SqlDataReader ExecuteCommand_(SqlCommand command)
        {
            Contract.Requires(command != null);
            Contract.Ensures(Contract.Result<SqlDataReader>() != null);

            return command.ExecuteReader(CommandBehavior);
        }

        [ContractInvariantMethod]
        [Conditional("CONTRACTS_FULL")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "[CodeContracts] Object Invariants.")]
        private void ObjectInvariants()
        {
            Contract.Invariant(_connectionString != null);
            Contract.Invariant(_connectionString.Length != 0);
            Contract.Invariant(_name != null);
            Contract.Invariant(_name.Length != 0);
        }
    }

    [ContractClassFor(typeof(StoredProcedure<>))]
    internal abstract class StoredProcedureContract<TResult> : StoredProcedure<TResult>
    {
        protected StoredProcedureContract(string connectionString, string name)
            : base(connectionString, name) { }

        protected override TResult Execute(SqlDataReader reader)
        {
            Contract.Requires(reader != null);

            return default(TResult);
        }

        protected override void PrepareParameters(SqlParameterCollection parameters)
        {
            Contract.Requires(parameters != null);
        }
    }
}