﻿Imports QLHSDTO
Imports QLHSBUS
Imports Utility
Public Class frmDangNhap
    Private NguoiDungKetQua As NguoiDungDTO
    Private ndbus As NGUOIDUNGBUS
    Public Property NguoiDungKetQua1 As NguoiDungDTO
        Get
            Return NguoiDungKetQua
        End Get
        Set(value As NguoiDungDTO)
            NguoiDungKetQua = value
        End Set
    End Property

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub frmDangNhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If tbxten.Text = "" Then
            MessageBox.Show("Hãy nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return

        End If
        If tbxpass.Text = "" Then
            MessageBox.Show("Hãy nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return
        End If
        ndbus = New NGUOIDUNGBUS()
        Dim listuser As List(Of NguoiDungDTO)
        listuser = New List(Of NguoiDungDTO)
        Dim result As Result
        result = ndbus.selectAll_bytdn(tbxten.Text, listuser)
        If result.FlagResult = False Then
            MessageBox.Show("Load danh sách người dùng không thành công")
            Return
        End If


        For index = 0 To listuser.Count - 1

            If (listuser(index).StrTenDangNhap = tbxten.Text) And (listuser(index).StrMatKhau = tbxpass.Text) Then
                MessageBox.Show("Đăng nhập thành công")
                NguoiDungKetQua = listuser(index)
                DialogResult = DialogResult.OK
                Close()
            Else
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)


            End If

        Next



    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ndbus = New NGUOIDUNGBUS()
        Dim listuser As List(Of NguoiDungDTO)
        listuser = New List(Of NguoiDungDTO)
        Dim result As Result
        result = ndbus.selectAll_bytdn("guest", listuser)
        If result.FlagResult = False Then
            MessageBox.Show("Có lỗi xảy ra khi load dữ liệu vui lòng liên hệ lập trình viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        NguoiDungKetQua = listuser(0)
        DialogResult = DialogResult.OK
        Close()
    End Sub
End Class