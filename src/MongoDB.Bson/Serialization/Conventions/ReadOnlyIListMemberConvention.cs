/* Copyright 2010-present MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System.Reflection;

namespace MongoDB.Bson.Serialization.Conventions
{
    /// <summary>
    /// Maps read-only properties which are ILists
    /// </summary>
    public class ReadOnlyIListMemberConvention : ConventionBase, IClassMapConvention
    {
        /// <inheritdoc />
        public void Apply(BsonClassMap classMap)
        {
            foreach (var property in classMap.ClassType.GetTypeInfo().GetProperties())
            {
                if (!property.CanWrite && typeof(System.Collections.IList).GetTypeInfo().IsAssignableFrom(property.PropertyType))
                {
                    classMap.MapMember(property);
                }
            }
        }
    }
}
