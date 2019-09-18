﻿/*****************************************************************************
   Copyright 2018 The TensorFlow.NET Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Tensorflow
{
    public partial class tensorflow
    {
        /// <summary>
        /// A convenient alias for None, useful for indexing arrays.
        /// </summary>
        public string newaxis = "";

        public Tensor check_numerics(Tensor tensor, string message, string name = null)
            => gen_array_ops.check_numerics(tensor, message, name: name);

        /// <summary>
        /// Concatenates tensors along one dimension.
        /// </summary>
        /// <param name="values">A list of `Tensor` objects or a single `Tensor`.</param>
        /// <param name="axis"></param>
        /// <param name="name"></param>
        /// <returns>A `Tensor` resulting from concatenation of the input tensors.</returns>
        public Tensor concat(IList<Tensor> values, int axis, string name = "concat")
        {
            if (values.Count == 1)
                throw new NotImplementedException("tf.concat length is 1");

            return gen_array_ops.concat_v2(values.ToArray(), axis, name: name);
        }

        /// <summary>
        /// Inserts a dimension of 1 into a tensor's shape.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="axis"></param>
        /// <param name="name"></param>
        /// <param name="dim"></param>
        /// <returns>
        /// A `Tensor` with the same data as `input`, but its shape has an additional
        /// dimension of size 1 added.
        /// </returns>
        public Tensor expand_dims(Tensor input, int axis = -1, string name = null, int dim = -1)
            => array_ops.expand_dims(input, axis, name, dim);

        /// <summary>
        /// Creates a tensor filled with a scalar value.
        /// </summary>
        /// <param name="dims"></param>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Tensor fill<T>(Tensor dims, T value, string name = null)
            => gen_array_ops.fill(dims, value, name: name);

        /// <summary>
        /// Gather slices from params axis axis according to indices.
        /// </summary>
        /// <param name="params"></param>
        /// <param name="indices"></param>
        /// <param name="name"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        public Tensor gather(Tensor @params, Tensor indices, string name = null, int axis = 0)
            => array_ops.gather(@params, indices, name: name, axis: axis);

        /// <summary>
        /// Return the elements, either from `x` or `y`, depending on the `condition`.
        /// </summary>
        /// <returns></returns>
        public Tensor where<Tx, Ty>(Tensor condition, Tx x, Ty y, string name = null)
            => array_ops.where(condition, x, y, name);

        /// <summary>
        /// Transposes `a`. Permutes the dimensions according to `perm`.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="perm"></param>
        /// <param name="name"></param>
        /// <param name="conjugate"></param>
        /// <returns></returns>
        public Tensor transpose<T1>(T1 a, int[] perm = null, string name = "transpose", bool conjugate = false)
            => array_ops.transpose(a, perm, name, conjugate);

        /// <summary>
        /// Returns the rank of a tensor.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="name"></param>
        /// <returns>Returns a 0-D `int32` `Tensor` representing the rank of `input`.</returns>
        public Tensor rank(Tensor input, string name = null)
            => array_ops.rank(input, name: name);

        /// <summary>
        /// Extracts a slice from a tensor.
        /// </summary>
        /// <param name="input">A `Tensor`.</param>
        /// <param name="begin">An `int32` or `int64` `Tensor`.</param>
        /// <param name="size">An `int32` or `int64` `Tensor`.</param>
        /// <param name="name">A name for the operation (optional).</param>
        /// <returns>A `Tensor` the same type as `input`.</returns>
        public Tensor slice<Tb, Ts>(Tensor input, Tb[] begin, Ts[] size, string name = null)
            => array_ops.slice(input, begin, size, name: name);

        public Tensor squeeze(Tensor input, int[] axis = null, string name = null, int squeeze_dims = -1)
            => gen_array_ops.squeeze(input, axis, name);

        /// <summary>
        /// Stacks a list of rank-`R` tensors into one rank-`(R+1)` tensor.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="axis"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Tensor stack(object values, int axis = 0, string name = "stack")
            => array_ops.stack(values, axis, name: name);

        /// <summary>
        /// Creates a tensor with all elements set to 1.
        /// </summary>
        /// <param name="tensor"></param>
        /// <param name="dtype"></param>
        /// <param name="name">A name for the operation (optional).</param>
        /// <param name="optimize">
        /// if true, attempt to statically determine the shape of 'tensor' and
        /// encode it as a constant.
        /// </param>
        /// <returns>A `Tensor` with all elements set to 1.</returns>
        public Tensor ones_like(Tensor tensor, TF_DataType dtype = TF_DataType.DtInvalid, string name = null, bool optimize = true)
            => array_ops.ones_like(tensor, dtype: dtype, name: name, optimize: optimize);

        public Tensor one_hot(Tensor indices, int depth,
            Tensor on_value = null,
            Tensor off_value = null,
            TF_DataType dtype = TF_DataType.DtInvalid,
            int axis = -1,
            string name = null) => array_ops.one_hot(indices, depth, dtype: dtype, axis: axis, name: name);

        /// <summary>
        /// Pads a tensor
        /// </summary>
        /// <param name="tensor"></param>
        /// <param name="paddings"></param>
        /// <param name="mode"></param>
        /// <param name="name"></param>
        /// <param name="constant_values"></param>
        /// <returns></returns>
        public Tensor pad(Tensor tensor, Tensor paddings, string mode = "CONSTANT", string name = null, int constant_values = 0)
            => array_ops.pad(tensor, paddings, mode: mode, name: name, constant_values: constant_values);

        /// <summary>
        /// A placeholder op that passes through `input` when its output is not fed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">A `Tensor`. The default value to produce when output is not fed.</param>
        /// <param name="shape">
        /// A `tf.TensorShape` or list of `int`s. The (possibly partial) shape of
        /// the tensor.
        /// </param>
        /// <param name="name">A name for the operation (optional).</param>
        /// <returns>A `Tensor`. Has the same type as `input`.</returns>
        public Tensor placeholder_with_default<T>(T input, int[] shape, string name = null)
            => gen_array_ops.placeholder_with_default(input, shape, name: name);

        /// <summary>
        /// Returns the shape of a tensor.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="name"></param>
        /// <param name="out_type"></param>
        /// <returns></returns>
        public Tensor shape(Tensor input, string name = null, TF_DataType out_type = TF_DataType.TF_INT32)
            => array_ops.shape_internal(input, name, optimize: true, out_type: out_type);

        /// <summary>
        /// Stacks a list of rank-`R` tensors into one rank-`(R+1)` tensor.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="axis"></param>
        /// <param name="name"></param>
        /// <returns>A stacked `Tensor` with the same type as `values`.</returns>
        public Tensor stack(Tensor[] values, int axis = 0, string name = "stack")
            => array_ops.stack(values, axis: axis, name: name);

        /// <summary>
        /// Unpacks the given dimension of a rank-`R` tensor into rank-`(R-1)` tensors.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="num"></param>
        /// <param name="axis"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Tensor[] unstack(Tensor value, int? num = null, int axis = 0, string name = "unstack")
            => array_ops.unstack(value, num: num, axis: axis, name: name);

        /// <summary>
        /// Creates a tensor with all elements set to zero.
        /// </summary>
        /// <param name="tensor"></param>
        /// <param name="dtype"></param>
        /// <param name="name"></param>
        /// <param name="optimize"></param>
        /// <returns>A `Tensor` with all elements set to zero.</returns>
        public Tensor zeros_like(Tensor tensor, TF_DataType dtype = TF_DataType.DtInvalid, string name = null, bool optimize = true)
            => array_ops.zeros_like(tensor, dtype: dtype, name: name, optimize: optimize);
    }
}
