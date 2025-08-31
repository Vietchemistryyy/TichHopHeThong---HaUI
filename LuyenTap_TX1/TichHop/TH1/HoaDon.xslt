<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"	
>
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/">
		<html>
			<head>
				<title>Danh sách hóa đơn</title>
				<style>
					table { border-collapse: collapse; width: 100%; margin-bottom: 30px; }
					th, td { border: 1px solid #000; padding: 8px; text-align: center; }
					th { background-color: #f2f2f2; }
					h2 { margin-top: 40px; }
				</style>
			</head>
			<body>
				<h1>Danh sách các hóa đơn</h1>

				<!-- Duyệt từng hóa đơn -->
				<xsl:for-each select="DS/HoaDon">
					<h2>
						Hóa đơn: <xsl:value-of select="MaHD"/> - Ngày bán: <xsl:value-of select="NgayBan"/>
					</h2>

					<!-- Duyệt từng loại hàng trong hóa đơn -->
					<xsl:for-each select="LoaiHang">
						<h3>
							Loại hàng: <xsl:value-of select="@TenLoai"/> (Mã: <xsl:value-of select="@MaLoai"/>)
						</h3>

						<table>
							<tr>
								<th>Mã hàng</th>
								<th>Tên hàng</th>
								<th>Số lượng</th>
								<th>Đơn vị tính</th>
								<th>Đơn giá</th>
								<th>Thành tiền</th>
							</tr>

							<!-- Duyệt từng mặt hàng -->
							<xsl:for-each select="Hang">
								<tr>
									<td>
										<xsl:value-of select="@MaHang"/>
									</td>
									<td>
										<xsl:value-of select="TenHang"/>
									</td>
									<td>
										<xsl:value-of select="SoLuong"/>
									</td>
									<td>
										<xsl:value-of select="DonViTinh"/>
									</td>
									<td>
										<xsl:value-of select="format-number(DonGia, '#,##0')"/>
									</td>
									<td>
										<xsl:variable name="soluong" select="number(SoLuong)"/>
										<xsl:variable name="dongia" select="number(DonGia)"/>
										<xsl:value-of select="format-number($soluong * $dongia, '#,##0')"/>
									</td>
								</tr>
							</xsl:for-each>
						</table>
					</xsl:for-each>
				</xsl:for-each>

			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
